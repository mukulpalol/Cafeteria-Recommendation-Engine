using CafeteriaRecommendationSystem.Common.DTO;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class FeedbackService : BaseService, IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMenuItemService _menuItemService;
        private readonly IRecommendationService _recommendationService;

        public FeedbackService(IFeedbackRepository feedbackRepository, IMenuItemService menuItemService, IRecommendationService recommendationService)
        {
            _feedbackRepository = feedbackRepository;
            _menuItemService = menuItemService;
            _recommendationService = recommendationService;
        }

        public string SubmitFeedback(FeedbackRequestDTO feedbackRequest)
        {
            Feedback feedback = new Feedback();
            feedback.MenuItemId = feedbackRequest.MenuItemId;
            feedback.UserId = feedbackRequest.UserId;
            feedback.Rating = feedbackRequest.Rating;
            feedback.Comment = feedbackRequest.Comment;
            feedback.SentimentScore = 0; //to update with sentiment analyser function

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

        bool CheckFeedbackAlreadySubmitted(Feedback feedback)
        {
            return _feedbackRepository.GetAll()
                .Any(f => f.UserId == feedback.UserId && f.MenuItemId == feedback.MenuItemId && f.Date.Date == feedback.Date.Date);
        }

        public List<Feedback> GetFeedbackByMenuItem(int menuItemId)
        {
            return _feedbackRepository.GetAll().Where(f => f.MenuItemId == menuItemId).ToList();
        }

        public List<Feedback> GetFeedbackByUser(int userId)
        {
            return _feedbackRepository.GetAll().Where(f => f.UserId == userId).ToList();
        }

    }
}
