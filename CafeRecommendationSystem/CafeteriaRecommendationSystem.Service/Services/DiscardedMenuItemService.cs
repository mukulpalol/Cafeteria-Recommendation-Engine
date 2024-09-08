using AutoMapper;
using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.Logging;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class DiscardedMenuItemService : IDiscardedMenuItemService
    {
        private readonly IDiscardedMenuItemRepository _discardedMenuItemRepository;
        private readonly IFeedbackService _feedbackService;
        private readonly IMenuItemService _menuItemService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly ILogger<DiscardedMenuItemService> _logger;

        #region Constructor
        public DiscardedMenuItemService(IDiscardedMenuItemRepository discardedMenuItemRepository, IMenuItemService menuItemService, IFeedbackService feedbackService, INotificationService notificationService, IMapper mapper, ILogger<DiscardedMenuItemService> logger)
        {
            _discardedMenuItemRepository = discardedMenuItemRepository;
            _feedbackService = feedbackService;
            _menuItemService = menuItemService;
            _notificationService = notificationService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region GenerateDiscardedMenuItem
        public string GenerateDiscardedMenuItem()
        {
            try
            {
                _logger.LogInformation("GenerateDiscardedMenuItem called");
                if (IsDiscardedItemGeneratedThisMonth())
                {
                    return "Discarded menu item already generated this month.";
                }
                var menuItemIds = _menuItemService.GetAllMenuItems().Where(s => s.SentimentScore <= 3).Select(mi => mi.Id).ToList();

                var feedbacks = _feedbackService.GetAverageRatingsOfFoodItems(menuItemIds, DateTime.Today);

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
                    DiscardedMenuItem discardedMenuItem = _mapper.Map<DiscardedMenuItem>(menuItem);
                    _discardedMenuItemRepository.Add(discardedMenuItem);
                    _menuItemService.UpdateMenuItemAvailability(menuItem, (int)AvailabilityStatusEnum.Discarded);
                }
                string message = "Few menu items have been discarded.";
                _notificationService.SendNotification(NotificationTypeEnum.MenuItemDiscarded, message);
                return "Discarded menu item generated successfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GenerateDiscardedMenuItem: {ex.Message}");
                return "Error in generating discarded menu items";
            }
        }
        #endregion

        #region IsDiscardedItemGeneratedThisMonth
        private bool IsDiscardedItemGeneratedThisMonth()
        {
            var discardedItem = _discardedMenuItemRepository.GetAll().OrderByDescending(item => item.CreatedDate).FirstOrDefault();
            if (discardedItem != null)
            {
                return (DateTime.Today - discardedItem.CreatedDate).TotalDays < 30;
            }
            return false;
        }
        #endregion

        # region HandleDiscardMenuItem
        public string HandleDiscardMenuItem(HandleMenuItemRequestDTO requestDTO)
        {
            try
            {
                _logger.LogInformation("HandleDiscardMenuItem called");
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
            catch (Exception ex)
            {
                _logger.LogError($"Error in HandleDiscardMenuItem: {ex.Message}");
                return "Error in hnadling discarded menu item";
            }
        }
        #endregion
    }
}
