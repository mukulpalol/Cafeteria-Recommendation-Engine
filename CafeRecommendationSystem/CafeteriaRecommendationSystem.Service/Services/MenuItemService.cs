using AutoMapper;
using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.Logging;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IRecommendationRepository _recommendationRepository;
        private readonly ICharacteristicRepository _characteristicRepository;
        private readonly IUserPreferenceRepository _userPreferenceRepository;
        private readonly IMenuItemCharacteristicRpository _menuItemCharacteristicRpository;
        private readonly INotificationService _notificationService;
        private readonly ISentimentAnalysisHelper _sentimentAnalysisHelper;
        private readonly IMapper _mapper;
        private readonly ILogger<MenuItemService> _logger;

        #region Constructor
        public MenuItemService(IMenuItemRepository menuItemRepository, IFeedbackRepository feedbackRepository, IRecommendationRepository recommendationRepository, ICharacteristicRepository characteristicRepository, INotificationService notificationService, ISentimentAnalysisHelper sentimentAnalysisHelper, IUserPreferenceRepository userPreferenceRepository, IMenuItemCharacteristicRpository menuItemCharacteristicRpository, IMapper mapper, ILogger<MenuItemService> logger)
        {
            _menuItemRepository = menuItemRepository;
            _feedbackRepository = feedbackRepository;
            _recommendationRepository = recommendationRepository;
            _characteristicRepository = characteristicRepository;
            _notificationService = notificationService;
            _sentimentAnalysisHelper = sentimentAnalysisHelper;
            _userPreferenceRepository = userPreferenceRepository;
            _menuItemCharacteristicRpository = menuItemCharacteristicRpository;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region AddMenuItem
        public void AddMenuItem(MenuItem menuItem)
        {
            try
            {
                _logger.LogInformation("AddMenuItem called");
                _menuItemRepository.Add(menuItem);
                string message = $"Menu item '{menuItem.Name}' added to menu.";
                _notificationService.SendNotification(NotificationTypeEnum.NewFoodItemAdded, message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AddMenuItem: {ex.Message}");
            }
        }
        #endregion

        #region UpdateMenuItem
        public void UpdateMenuItem(MenuItemUpdateRequestDTO menuItem)
        {
            try
            {
                _logger.LogInformation("UpdateMenuItem called");
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
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateMEnuItem: {ex.Message}");
            }
        }
        #endregion

        #region UpdateMenuItemAvailability
        public void UpdateMenuItemAvailability(MenuItem menuItem, int AvailabilityStatusId)
        {
            try
            {
                _logger.LogInformation("UpdateMenuItemAvailability called");
                string message = $"Availability of {menuItem.Name} changed to {(AvailabilityStatusEnum)AvailabilityStatusId}";
                _notificationService.SendNotification(NotificationTypeEnum.FoodItemAvailabilityUpdated, message);
                menuItem.AvailabilityStatusId = AvailabilityStatusId;
                _menuItemRepository.Update(menuItem);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateMenuItemAvailability: {ex.Message}");
            }
        }
        #endregion

        #region UpdateSentimentScoreOfMenuItem
        public void UpdateSentimentScoreOfMenuItem(int menuItemId)
        {
            try
            {
                _logger.LogInformation("UpdateSentimentScoreOfMenuItem called");
                var comments = _feedbackRepository.GetAll().Where(f => f.MenuItemId == menuItemId).Select(c => c.Comment).ToList();
                var sentimentScore = _sentimentAnalysisHelper.CalculateCommentSentimentScore(comments);
                var menuItem = _menuItemRepository.GetById(menuItemId);
                menuItem.SentimentScore = sentimentScore;
                _menuItemRepository.Update(menuItem);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateSentimentScoreOfMenuItem: {ex.Message}");
            }
        }
        #endregion

        #region UpdateSentimentSummaryOfMenuItem
        public void UpdateSentimentSummaryOfMenuItem(int menuItemId)
        {
            try
            {
                _logger.LogInformation("UpdateSentimentSummaryOfMenuItem called");
                var comments = _feedbackRepository.GetAll().Where(f => f.MenuItemId == menuItemId).Select(c => c.Comment).ToList();
                var sentiment = _sentimentAnalysisHelper.GetCommentSummary(comments);
                var menuItem = _menuItemRepository.GetById(menuItemId);
                menuItem.GeneralSentiment = sentiment;
                _menuItemRepository.Update(menuItem);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateSentimentSummaryOfMenuItem: {ex.Message}");
            }
        }
        #endregion

        #region DeleteMenuItem
        public void DeleteMenuItem(int menuItemId)
        {
            try
            {
                _logger.LogInformation("DeleteMenuItem called");
                var menuItem = _menuItemRepository.GetById(menuItemId);
                string message = $"Menu item {menuItem.Name} removed from the menu.";
                _notificationService.SendNotification(NotificationTypeEnum.FoodItemRemoved, message);
                menuItem.AvailabilityStatusId = (int)AvailabilityStatusEnum.Deleted;
                _menuItemRepository.Update(menuItem);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DeleteMenuItem: {ex.Message}");
            }
        }
        #endregion

        #region GetAllMenuItems
        public List<MenuItem> GetAllMenuItems()
        {
            try
            {
                _logger.LogInformation("GetAllMenuItems called");
                return _menuItemRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllMenuItems: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetMenuItemById
        public MenuItem GetMenuItemById(int menuItemId)
        {
            try
            {
                _logger.LogInformation("GetMenuItemById called");
                return _menuItemRepository.GetById(menuItemId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetMenuItemById: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetAvailableMenuItems
        public List<MenuItemResponseDTO> GetAvailableMenuItems()
        {
            try
            {
                _logger.LogInformation("GetAvailableMenuItems called");
                var menuItem = _menuItemRepository.GetAll().Where(m => m.AvailabilityStatusId == (int)AvailabilityStatusEnum.Available).ToList();
                List<MenuItemResponseDTO> menuItems = new List<MenuItemResponseDTO>();
                foreach (var item in menuItem)
                {
                    MenuItemResponseDTO respponse = _mapper.Map<MenuItemResponseDTO>(item);
                    menuItems.Add(respponse);
                }
                return menuItems;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAvailableMenuItems: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetMenuItemsThatAreDiscarded
        public List<MenuItemResponseDTO> GetMenuItemsThatAreDiscarded()
        {
            try
            {
                _logger.LogInformation("GetMenuItemsThatAreDiscarded called");
                var discardeMenuItems = _menuItemRepository.GetAll().Where(m => m.AvailabilityStatusId == (int)AvailabilityStatusEnum.Discarded).ToList();
                List<MenuItemResponseDTO> menuItems = new List<MenuItemResponseDTO>();
                foreach (var item in discardeMenuItems)
                {
                    MenuItemResponseDTO respponse = _mapper.Map<MenuItemResponseDTO>(item);
                    menuItems.Add(respponse);
                }
                return menuItems;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetMenuItemsThatAreDiscarded: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetRolledOutMenu
        public List<MenuItemResponseDTO> GetRolledOutMenu(int userId)
        {
            try
            {
                _logger.LogInformation("GetRolledOutMenu called");
                List<MenuItemResponseDTO> items = new List<MenuItemResponseDTO>();
                var menuItemIdsWithRecommendationToday = _recommendationRepository.GetAll()
                    .Where(r => r.RecommendationDate.Date == DateTime.Today)
                    .Select(r => r.MenuItemId)
                    .ToList();
                var userPreferences = _userPreferenceRepository.GetAll().Where(up => up.UserId == userId)
                                                  .Select(up => up.CharacteristicId)
                                                  .ToHashSet();
                foreach (var menuItemId in menuItemIdsWithRecommendationToday)
                {
                    items.Add(_mapper.Map<MenuItemResponseDTO>(_menuItemRepository.GetById(menuItemId)));
                }
                if (userPreferences.Count == 0)
                {
                    return items;
                }
                var menuItemsWithCharacteristics = items.Select(menuItem => new
                {
                    MenuItem = menuItem,
                    Characteristics = _menuItemCharacteristicRpository.GetAll().Where(mic => mic.MenuItemId == menuItem.Id)
                                                          .Select(mic => mic.CharacteristicId)
                                                          .ToList()
                }).ToList();
                var sortedMenuItems = menuItemsWithCharacteristics.OrderByDescending(item => item.Characteristics
                                                            .Count(c => userPreferences.Contains(c)))
                                                            .ThenBy(item => item.Characteristics.Count > 0 ? 0 : 1)
                                                            .ThenBy(item => item.MenuItem.Id)
                                                            .Select(item => item.MenuItem)
                                                            .ToList();
                return sortedMenuItems;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetRolledOutMenu: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetFinalisedMenu
        public List<MenuItemResponseDTO> GetFinalisedMenu()
        {
            try
            {
                _logger.LogInformation("GetFinalisedMenu called");
                var menuItemIdsWithRecommendationToday = _recommendationRepository.GetAll()
                    .Where(r => r.RecommendationDate.Date.Date == DateTime.Today.Date && r.IsFinalised == true)
                    .Select(r => r.MenuItemId)
                    .ToList();
                List<MenuItemResponseDTO> finalisedMenu = new List<MenuItemResponseDTO>();
                foreach (var menuItemId in menuItemIdsWithRecommendationToday)
                {
                    finalisedMenu.Add(_mapper.Map<MenuItemResponseDTO>(_menuItemRepository.GetById(menuItemId)));
                }
                return finalisedMenu;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetFinalisedMenu: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetAllFoodCharacteristic
        public List<ViewFoodCharacteristicsResponseDTO> GetAllFoodCharacteristic()
        {
            try
            {
                _logger.LogInformation("GetAllFoodCharacteristic called");
                var characteristics = _characteristicRepository.GetAll().Select(c => new ViewFoodCharacteristicsResponseDTO { Id = c.Id, Characteristic = c.Name }).ToList();
                return characteristics;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllFoodCharacteristic: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
