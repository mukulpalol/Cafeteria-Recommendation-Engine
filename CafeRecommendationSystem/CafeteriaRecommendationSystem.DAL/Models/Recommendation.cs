namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class Recommendation
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public DateTime RecommendationDate { get; set; }
        public bool IsFinalised { get; set; }
        public virtual MenuItem MenuItem { get; set; } = null!;
    }
}
