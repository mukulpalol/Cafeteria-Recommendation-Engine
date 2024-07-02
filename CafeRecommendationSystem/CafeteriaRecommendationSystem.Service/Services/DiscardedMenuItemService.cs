using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class DiscardedMenuItemService : IDiscardedMenuItemService
    {
        private readonly IDiscardedMenuItemRepository _discardedMenuItemRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMenuItemService _menuItemService;
        private readonly INotificationService _notificationService;

        public DiscardedMenuItemService(IDiscardedMenuItemRepository discardedMenuItemRepository, IFeedbackRepository feedbackRepository, IMenuItemService menuItemService, INotificationService notificationService)
        {
            _discardedMenuItemRepository = discardedMenuItemRepository;
            _feedbackRepository = feedbackRepository;
            _menuItemService = menuItemService;
            _notificationService = notificationService;
        }

        public string GenerateDiscardedMenuItem()
        {
            if (IsDiscardedItemGeneratedThisMonth())
            {
                return "Discarded menut item already generated this month.";
            }
            var menuItemIds = _menuItemService.GetAllMenuItems().Where(s => s.SentimentScore <= 3).Select(mi => mi.Id).ToList();

            var feedbacks = _feedbackRepository.GetAll()
                .Where(f => menuItemIds.Contains(f.MenuItemId))
                .GroupBy(f => f.MenuItemId)
                .Select(group => new
                {
                    MenuItemId = group.Key,
                    AverageRating = group.Average(f => f.Rating)
                })
                .ToList();

            var menuItemsToDiscard = _menuItemService.GetAllMenuItems().Where(s => s.SentimentScore <= 3)
                .Join(feedbacks, mi => mi.Id, f => f.MenuItemId, (mi, f) => new
                {
                    MenuItem = mi,
                    AverageRating = f.AverageRating
                })
                .Where(item => item.AverageRating <= 2)
                .OrderByDescending(item => item.AverageRating)
                .ThenByDescending(item => item.MenuItem.SentimentScore)
                .Select(item => item.MenuItem)
                .ToList();

            foreach (var menuItem in menuItemsToDiscard)
            {
                DiscardedMenuItem discardedMenuItem = new DiscardedMenuItem()
                {
                    MenuItemId = menuItem.Id,
                    MenuItem = menuItem,
                    CreatedDate = DateTime.UtcNow
                };
                _discardedMenuItemRepository.Add(discardedMenuItem);
                _menuItemService.UpdateMenuItemAvailability(menuItem, (int)AvailabilityStatusEnum.Discarded);
            }
            string message = "Few menu items have been discarded.";
            _notificationService.SendNotification(NotificationTypeEnum.MenuItemDiscarded, message);
            return "Discarded menu item generated successfully.";
        }

        public bool IsDiscardedItemGeneratedThisMonth()
        {
            var discardedItem = _discardedMenuItemRepository.GetAll().OrderByDescending(item => item.CreatedDate).FirstOrDefault();
            if (discardedItem != null)
            {
                return (DateTime.UtcNow - discardedItem.CreatedDate).TotalDays < 30;
            }
            return false;
        }

        public string HandleDiscardMenuItem(HandleMenuItemRequestDTO requestDTO)
        {
            var menuItem = _menuItemService.GetMenuItemById(requestDTO.MenuItemId);
            if (menuItem != null)
            {
                if (menuItem.AvailabilityStatusId == (int)AvailabilityStatusEnum.Discarded)
                {
                    _menuItemService.UpdateMenuItemAvailability(menuItem, requestDTO.Choice);
                    return "Handled successfully";
                }
                return "Menu item is not in discarded list.";
            }
            return "Invalid menu item id";
        }
    }
}
