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
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMenuItemService _menuItemService;
        private readonly IDiscardedMenuItemFeedbackRepository _discardedMenuItemFeedbackRepository;
        private readonly IRecommendationService _recommendationService;
        private readonly IMapper _mapper;
        private readonly ILogger<FeedbackService> _logger;

        #region Constructor
        public FeedbackService(IFeedbackRepository feedbackRepository, IMenuItemService menuItemService, IDiscardedMenuItemFeedbackRepository discardedMenuItemFeedbackRepository, IRecommendationService recommendationService, IMapper mapper, ILogger<FeedbackService> logger)
        {
            _feedbackRepository = feedbackRepository;
            _menuItemService = menuItemService;
            _discardedMenuItemFeedbackRepository = discardedMenuItemFeedbackRepository;
            _recommendationService = recommendationService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region SubmitFeedback
        public string SubmitFeedback(FeedbackRequestDTO feedbackRequest)
        {
            try
            {
                _logger.LogInformation("SubmitFeedback called");
                Feedback feedback = _mapper.Map<Feedback>(feedbackRequest);

                if (!_recommendationService.CheckMenuItemWasFinalised(feedback.MenuItemId))
                {
                    return $"Menu item {feedback.MenuItemId} was not made today.";
                }
                if (CheckFeedbackAlreadySubmitted(feedback))
                {
                    return $"Feedback of menu item {feedback.MenuItemId} already submitted for today.";
                }
                _feedbackRepository.Add(feedback);
                _menuItemService.UpdateSentimentScoreOfMenuItem(feedback.MenuItemId);
                return "Feedback submitted successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in SubmitFeedback: {ex.Message}");
                return "Error in submitting feedback";
            }
        }
        #endregion

        #region SubmitFeedbackOfDiscardedMenuItm
        public string SubmitFeedbackOfDiscardedMenuItm(DiscardedMenuItemFeedbackRequestDTO discardedMenuItemFeedbackRequest)
        {
            try
            {
                _logger.LogInformation("SubmitFeedbackOfDiscardedMenuItm called");
                var menuItem = _menuItemService.GetMenuItemById(discardedMenuItemFeedbackRequest.MenuItemId);
                if (menuItem != null)
                {
                    if (menuItem.AvailabilityStatusId == (int)AvailabilityStatusEnum.Discarded)
                    {
                        DiscardedMenuItemFeedback itemFeedback = _mapper.Map<DiscardedMenuItemFeedback>(discardedMenuItemFeedbackRequest);
                        itemFeedback.Date = DateTime.Today;
                        _discardedMenuItemFeedbackRepository.Add(itemFeedback);

                        return "Feedback submitted successfullly";
                    }
                    return "Menu item is not in discarded list";
                }
                return "Invalid menu item id entered";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in SubmitFeedbackOfDiscardedMenuItm: {ex.Message}");
                return "Error in submitting feedback of discarded menu items";
            }
        }

        bool CheckFeedbackAlreadySubmitted(Feedback feedback)
        {
            return _feedbackRepository.GetAll()
                .Any(f => f.UserId == feedback.UserId && f.MenuItemId == feedback.MenuItemId && f.Date.Date == feedback.Date.Date);
        }
        #endregion

        #region GetFeedbackByMenuItem
        public List<Feedback> GetFeedbackByMenuItem(int menuItemId)
        {
            return _feedbackRepository.GetAll().Where(f => f.MenuItemId == menuItemId).ToList();
        }
        #endregion

        #region GetFeedbackByUser
        public List<Feedback> GetFeedbackByUser(int userId)
        {
            return _feedbackRepository.GetAll().Where(f => f.UserId == userId).ToList();
        }
        #endregion

        #region GetAverageRatingsOfFoodItems
        public List<MenuItemAverageRatingDTO> GetAverageRatingsOfFoodItems(List<int> menuItemIds, DateTime date)
        {
            try
            {
                _logger.LogInformation("GetAverageRatingsOfFoodItems called");
                var lastWeekDate = DateTime.Now.AddDays(-7);
                var feedbacks = _feedbackRepository.GetAll()
                    .Where(f => f.Date <= date && menuItemIds.Contains(f.MenuItemId))
                    .GroupBy(f => f.MenuItemId)
                    .Select(group => new MenuItemAverageRatingDTO
                    {
                        MenuItemId = group.Key,
                        AverageRating = group.Average(f => f.Rating)
                    })
                    .ToList();
                return feedbacks;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAverageRatingsOfFoodItems: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
