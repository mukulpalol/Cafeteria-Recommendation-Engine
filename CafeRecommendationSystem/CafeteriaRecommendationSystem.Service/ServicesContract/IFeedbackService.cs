using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.Service.ServicesContract
{
    public interface IFeedbackService
    {
        string SubmitFeedback(FeedbackRequestDTO feedback);
        string SubmitFeedbackOfDiscardedMenuItm(DiscardedMenuItemFeedbackRequestDTO discardedMenuItemFeedbackRequest);
        List<Feedback> GetFeedbackByMenuItem(int menuItemId);
        List<Feedback> GetFeedbackByUser(int userId);
        List<MenuItemAverageRatingDTO> GetAverageRatingsOfFoodItems(List<int> menuItemIds, DateTime date);
    }
}