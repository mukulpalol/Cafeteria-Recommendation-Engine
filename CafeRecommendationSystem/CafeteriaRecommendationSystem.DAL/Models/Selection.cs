namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class Selection
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MenuItemId { get; set; }
        public DateTime Date { get; set; }
        public virtual MenuItem MenuItem { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
