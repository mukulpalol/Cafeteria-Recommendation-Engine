using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IRecommendationRepository _recommendationRepository;
        private readonly INotificationService _notificationService;
        private readonly ISentimentAnalysisHelper _sentimentAnalysisHelper;

        public MenuItemService(IMenuItemRepository menuItemRepository, IFeedbackRepository feedbackRepository, IRecommendationRepository recommendationRepository, INotificationService notificationService, ISentimentAnalysisHelper sentimentAnalysisHelper)
        {
            _menuItemRepository = menuItemRepository;
            _feedbackRepository = feedbackRepository;
            _recommendationRepository = recommendationRepository;
            _notificationService = notificationService;
            _sentimentAnalysisHelper = sentimentAnalysisHelper;
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            _menuItemRepository.Add(menuItem);
            string message = $"Menu item '{menuItem.Name}' added to menu.";
            _notificationService.SendNotification(NotificationTypeEnum.NewFoodItemAdded, message);
        }

        public void UpdateMenuItem(MenuItemUpdateRequestDTO menuItem)
        {
            var menuItemToUpdate = _menuItemRepository.GetById(menuItem.Id);
            if (menuItemToUpdate != null)
            {
                if (menuItem.Name != string.Empty) menuItemToUpdate.Name = menuItem.Name;
                if (menuItem.Price != null)
                {
                    string message = $"Price of {menuItemToUpdate.Name} updated to {menuItem.Price}";
                    _notificationService.SendNotification(NotificationTypeEnum.FoodItemPriceUpdated, message);
                    menuItemToUpdate.Price = (decimal)menuItem.Price;
                }
                if (menuItem.TypeId != null) menuItemToUpdate.TypeId = (int)menuItem.TypeId;
                if (menuItem.AvailabilityStatusId != null)
                {
                    string message = $"Availability of {menuItemToUpdate.Name} changed to {(AvailabilityStatusEnum)menuItem.AvailabilityStatusId}";
                    _notificationService.SendNotification(NotificationTypeEnum.FoodItemAvailabilityUpdated, message);
                    menuItemToUpdate.AvailabilityStatusId = (int)menuItem.AvailabilityStatusId;
                }
                _menuItemRepository.Update(menuItemToUpdate);
            }
        }

        public void UpdateMenuItemAvailability(MenuItem menuItem, int AvailabilityStatusId)
        {
            string message = $"Availability of {menuItem.Name} changed to {(AvailabilityStatusEnum)AvailabilityStatusId}";
            _notificationService.SendNotification(NotificationTypeEnum.FoodItemAvailabilityUpdated, message);
            menuItem.AvailabilityStatusId = AvailabilityStatusId;
            _menuItemRepository.Update(menuItem);
        }

        public void UpdateSentimentScoreOfMenuItem(int menuItemId)
        {
            var comments = _feedbackRepository.GetAll().Where(f => f.MenuItemId == menuItemId).Select(c => c.Comment).ToList();
            var sentimentScore = _sentimentAnalysisHelper.CalculateCommentSentimentScore(comments);            
            var menuItem = _menuItemRepository.GetById(menuItemId);
            menuItem.SentimentScore = sentimentScore;
            _menuItemRepository.Update(menuItem);
        }

        public void DeleteMenuItem(int menuItemId)
        {
            var menuItem = _menuItemRepository.GetById(menuItemId);
            string message = $"Menu item {menuItem.Name} removed from the menu.";
            _notificationService.SendNotification(NotificationTypeEnum.FoodItemRemoved, message);
            menuItem.AvailabilityStatusId = (int)AvailabilityStatusEnum.Deleted;
            _menuItemRepository.Update(menuItem);
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _menuItemRepository.GetAll().ToList();
        }

        public MenuItem GetMenuItemById(int menuItemId)
        {
            return _menuItemRepository.GetById(menuItemId);
        }

        public List<MenuItem> GetAvailableMenuItems()
        {
            return _menuItemRepository.GetAll().Where(m => m.AvailabilityStatusId == (int)AvailabilityStatusEnum.Available).ToList();
        }

        public List<MenuItem> GetMenuItemsThatAreDiscarded()
        {
            return _menuItemRepository.GetAll().Where(m => m.AvailabilityStatusId == (int)AvailabilityStatusEnum.Discarded).ToList();
        }

        public List<MenuItem> GetRolledOutMenu()
        {
            var menuItemIdsWithRecommendationToday = _recommendationRepository.GetAll()
                .Where(r => r.RecommendationDate.Date == DateTime.UtcNow)
                .Select(r => r.MenuItemId)
                .ToList();
            List<MenuItem> rolledOutMenu = new List<MenuItem>();
            foreach (var menuItemId in menuItemIdsWithRecommendationToday)
            {
                rolledOutMenu.Add(_menuItemRepository.GetById(menuItemId));
            }
            return rolledOutMenu;
        }

        public List<MenuItem> GetFinalisedMenu()
        {
            var menuItemIdsWithRecommendationToday = _recommendationRepository.GetAll()
                .Where(r => r.RecommendationDate.Date == DateTime.UtcNow && r.IsFinalised == true)
                .Select(r => r.MenuItemId)
                .ToList();
            List<MenuItem> finalisedMenu = new List<MenuItem>();
            foreach (var menuItemId in menuItemIdsWithRecommendationToday)
            {
                finalisedMenu.Add(_menuItemRepository.GetById(menuItemId));
            }
            return finalisedMenu;
        }
    }
}
