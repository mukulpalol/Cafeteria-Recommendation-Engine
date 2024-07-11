using AutoMapper;
using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMenuItemService _menuItemService;
        private readonly IDiscardedMenuItemFeedbackRepository _discardedMenuItemFeedbackRepository;
        private readonly IRecommendationService _recommendationService;
        private readonly IMapper _mapper;

        #region Constructor
        public FeedbackService(IFeedbackRepository feedbackRepository, IMenuItemService menuItemService, IDiscardedMenuItemFeedbackRepository discardedMenuItemFeedbackRepository, IRecommendationService recommendationService, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _menuItemService = menuItemService;
            _discardedMenuItemFeedbackRepository = discardedMenuItemFeedbackRepository;
            _recommendationService = recommendationService;
            _mapper = mapper;
        }
        #endregion

        #region SubmitFeedback
        public string SubmitFeedback(FeedbackRequestDTO feedbackRequest)
        {
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
        #endregion

        #region SubmitFeedbackOfDiscardedMenuItm
        public string SubmitFeedbackOfDiscardedMenuItm(DiscardedMenuItemFeedbackRequestDTO discardedMenuItemFeedbackRequest)
        {
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

    }
}
