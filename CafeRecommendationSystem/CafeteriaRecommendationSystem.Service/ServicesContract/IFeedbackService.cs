using CafeteriaRecommendationSystem.Common.DTO;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IFeedbackService : IBaseService
    {
        string SubmitFeedback(FeedbackRequestDTO feedback);
        List<Feedback> GetFeedbackByMenuItem(int menuItemId);
        List<Feedback> GetFeedbackByUser(int userId);
    }
}