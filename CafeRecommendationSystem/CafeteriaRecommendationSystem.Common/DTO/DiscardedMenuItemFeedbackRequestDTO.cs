namespace CafeteriaRecommendationSystem.Common.DTO
{
    public class DiscardedMenuItemFeedbackRequestDTO
    {
        public int MenuItemId { get; set; }
        public int UserId { get; set; }
        public string Feedback { get; set; }
    }
}
