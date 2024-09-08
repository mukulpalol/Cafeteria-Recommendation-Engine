using AutoMapper;
using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;
using Microsoft.Extensions.Logging;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class RecommendationService : IRecommendationService
    {        
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IRecommendationRepository _recommendationRepository;
        private readonly INotificationService _notificationService;
        private readonly IFeedbackService _feeedbackService;
        private readonly IMapper _mapper;
        private readonly ILogger<RecommendationService> _logger;

        #region Constructor
        public RecommendationService(IMenuItemRepository menuItemRepository, IRecommendationRepository recommendationRepository, INotificationService notificationService, IFeedbackService feeedbackService, IMapper mapper, ILogger<RecommendationService> logger)
        {            
            _menuItemRepository = menuItemRepository;
            _recommendationRepository = recommendationRepository;
            _notificationService = notificationService;
            _feeedbackService = feeedbackService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region GetRecommendations
        public List<MenuItemResponseDTO> GetRecommendations(int numberOfRecommendations, MenuItemTypeEnum menuItemType)
        {
            try
            {
                _logger.LogInformation("GetRecommendations called");
                var lastWeekDate = DateTime.Now.AddDays(-7);
                var menuItems = _menuItemRepository.GetAll()
                    .Where(mi => mi.TypeId == (int)menuItemType && mi.AvailabilityStatusId == 1)
                    .ToList();

                var menuItemIds = menuItems.Select(mi => mi.Id).ToList();

                var feedbacks = _feeedbackService.GetAverageRatingsOfFoodItems(menuItemIds, lastWeekDate);

                var recommendations = menuItems
                    .Join(feedbacks, mi => mi.Id, f => f.MenuItemId, (mi, f) => new { MenuItem = mi, f.AverageRating })
                    .OrderByDescending(item => item.AverageRating)
                    .ThenByDescending(item => item.MenuItem.SentimentScore)
                    .Take(numberOfRecommendations)
                    .Select(item => item.MenuItem)
                    .ToList();

                List<MenuItemResponseDTO> responses = new List<MenuItemResponseDTO>();
                foreach (var menuItem in recommendations)
                {
                    MenuItemResponseDTO menuItemResponse = _mapper.Map<MenuItemResponseDTO>(menuItem);
                    responses.Add(menuItemResponse);
                }

                return responses;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetRecommendations: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region RollOutMenu
        public void RollOutMenu(List<int> menuItemIdList)
        {
            try
            {
                _logger.LogInformation("RollOutMenu called");
                foreach (var menuItemId in menuItemIdList)
                {
                    var menuItem = _menuItemRepository.GetById(menuItemId);
                    Recommendation recommendation = new Recommendation()
                    {
                        MenuItemId = menuItemId,
                        MenuItem = menuItem,
                        RecommendationDate = DateTime.Today,
                        IsFinalised = false
                    };
                    if (!CheckMenuItemWasRecommended(recommendation))
                    {
                        _recommendationRepository.Add(recommendation);
                    }
                    string message = $"Rolled out menu for {DateTime.Today.AddDays(1).ToString("dd-MM-yyyy")}";
                    _notificationService.SendNotification(NotificationTypeEnum.MenuRolledOut, message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in RollOutMenu: {ex.Message}");
            }
        }

        private bool CheckMenuItemWasRecommended(Recommendation recommendation)
        {
            return _recommendationRepository.GetAll().Any(r => r.MenuItemId == recommendation.MenuItemId && r.RecommendationDate.Date == recommendation.RecommendationDate);
        }
        #endregion

        #region FinaliseMenu
        public string FinaliseMenu(List<int> menuItemIdList)
        {
            try
            {
                _logger.LogInformation("FinaliseMenu called");
                foreach (var menuItemId in menuItemIdList)
                {
                    var recommendation = GetRecommendationByMenuItem(menuItemId);
                    if (recommendation == null)
                    {
                        return "Entered menu item was not rolled out - Finalising unsuccessful";
                    }
                }
                foreach (var menuItemId in menuItemIdList)
                {
                    var recommendation = GetRecommendationByMenuItem(menuItemId);
                    if (recommendation != null)
                    {
                        recommendation.IsFinalised = true;
                        UpdateRecommendation(recommendation);
                    }
                }
                string message = $"Menu finalised for {DateTime.Today.AddDays(1).ToString("dd-MM-yyyy")}";
                _notificationService.SendNotification(NotificationTypeEnum.MenuRolledOut, message);
                return "Menu finalised";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in FinaliseMenu: {ex.Message}");
                return $"Error in FinaliseMenu: {ex.Message}";
            }
        }
        #endregion

        #region UpdateRecommendation
        public void UpdateRecommendation(Recommendation recommendation)
        {
            try
            {
                _logger.LogInformation("UpdateRecommendation called");
                _recommendationRepository.Update(recommendation);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateRecommendation: {ex.Message}");
            }
        }
        #endregion

        #region GetRecommendationByMenuItem
        public Recommendation GetRecommendationByMenuItem(int menuItemId)
        {
            try
            {
                _logger.LogInformation("GetRecommendationByMenuItem called");
                var recommendation = _recommendationRepository.GetAll().Where(e => e.MenuItemId == menuItemId && e.RecommendationDate == DateTime.Today).FirstOrDefault();
                return recommendation;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetRecommendationByMenuItem: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion        
    }
}
