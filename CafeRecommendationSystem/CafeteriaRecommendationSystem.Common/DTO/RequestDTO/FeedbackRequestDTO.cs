namespace CafeteriaRecommendationSystem.Common.DTO.RequestDTO
{
    public class FeedbackRequestDTO
    {
        public int MenuItemId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
