namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class Recommendation
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public DateTime DateRecommended { get; set; }
        public decimal RecommendationScore { get; set; }
        public virtual MenuItem MenuItem { get; set; } = null!;
    }
}
