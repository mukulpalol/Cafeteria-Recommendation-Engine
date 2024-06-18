namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null;
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; } = null;
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }        
    }
}
