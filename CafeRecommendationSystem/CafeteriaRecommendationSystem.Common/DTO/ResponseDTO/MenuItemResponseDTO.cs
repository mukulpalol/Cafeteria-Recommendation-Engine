namespace CafeteriaRecommendationSystem.Common.DTO.ResponseDTO
{
    public class MenuItemResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string Availability { get; set; }
        public decimal SentimentScore { get; set; }
        public string? GeneralSentiment { get; set; }
    }
}
