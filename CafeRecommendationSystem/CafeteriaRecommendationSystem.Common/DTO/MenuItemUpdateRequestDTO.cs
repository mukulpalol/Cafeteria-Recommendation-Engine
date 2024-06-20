namespace CafeteriaRecommendationSystem.Common.DTO
{
    public class MenuItemUpdateRequestDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public int? TypeId { get; set; }
        public int? AvailabilityStatusId { get; set; }
    }
}
