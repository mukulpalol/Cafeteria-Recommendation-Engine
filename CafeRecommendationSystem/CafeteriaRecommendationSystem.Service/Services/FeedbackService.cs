using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;
using CafeteriaRecommendationSystem.Service.ServicesContract;

namespace CafeteriaRecommendationSystem.Service.Services
{
    public class FeedbackService : BaseService, IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public void SubmitFeedback(User user, Feedback feedback)
        {
            EnsureRole(user, RoleEnum.Employee);
            feedback.UserId = user.Id;
            _feedbackRepository.Add(feedback);
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
