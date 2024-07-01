using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class MenuItemService : BaseService, IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IRecommendationRepository _recommendationRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository, IFeedbackRepository feedbackRepository, IRecommendationRepository recommendationRepository)
        {
            _menuItemRepository = menuItemRepository;
            _feedbackRepository = feedbackRepository;
            _recommendationRepository = recommendationRepository;
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            _menuItemRepository.Add(menuItem);
        }

        public void UpdateMenuItem(MenuItemUpdateRequestDTO menuItem)
        {
            var menuItemToUpdate = _menuItemRepository.GetById(menuItem.Id);
            if (menuItemToUpdate != null)
            {
                if (menuItem.Name != string.Empty) menuItemToUpdate.Name = menuItem.Name;
                if (menuItem.Price != null) menuItemToUpdate.Price = (decimal)menuItem.Price;
                if (menuItem.TypeId != null) menuItemToUpdate.TypeId = (int)menuItem.TypeId;
                if (menuItem.AvailabilityStatusId != null) menuItemToUpdate.AvailabilityStatusId = (int)menuItem.AvailabilityStatusId;
                _menuItemRepository.Update(menuItemToUpdate);
            }
        }

        public void UpdateMenuItemAvailability(User user, MenuItem menuItem, int AvailabilityStatusId)
        {
            EnsureRole(user, RoleEnum.Chef);
            menuItem.AvailabilityStatusId = AvailabilityStatusId;
            _menuItemRepository.Update(menuItem);
        }

        public void UpdateSentimentScoreOfMenuItem(int menuItemId)
        {
            var sentimentScore = _feedbackRepository.GetAll().Where(f => f.MenuItemId == menuItemId).Average(f => f.SentimentScore);
            var menuItem = _menuItemRepository.GetById(menuItemId);
            menuItem.SentimentScore = (decimal)sentimentScore;
            _menuItemRepository.Update(menuItem);
        }

        public void DeleteMenuItem(int menuItemId)
        {
            var menuItem = _menuItemRepository.GetById(menuItemId);
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

        public List<MenuItem> GetRolledOutMenu()
        {
            var menuItemIdsWithRecommendationToday = _recommendationRepository.GetAll()
                .Where(r => r.RecommendationDate.Date == DateTime.UtcNow)
                .Select(r => r.MenuItemId)
                .ToList();
            List<MenuItem> rolledOutMenu = new List<MenuItem>();
            foreach(var menuItemId in menuItemIdsWithRecommendationToday)
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
