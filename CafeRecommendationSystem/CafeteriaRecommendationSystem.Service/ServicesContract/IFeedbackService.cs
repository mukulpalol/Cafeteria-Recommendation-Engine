using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IFeedbackService : IBaseService
    {
        void SubmitFeedback(User user, Feedback feedback);
        List<Feedback> GetFeedbackByMenuItem(int menuItemId);
        List<Feedback> GetFeedbackByUser(int userId);
    }
}