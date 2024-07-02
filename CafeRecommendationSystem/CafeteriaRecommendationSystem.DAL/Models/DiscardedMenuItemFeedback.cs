namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class DiscardedMenuItemFeedback
    {
        public int Id { get; set; }
        public int DiscardedMenuItemId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Feedback { get; set; }
        public virtual DiscardedMenuItem DiscardedMenuItem { get; set; } = null;
        public virtual User User { get; set; } = null;
    }
}
