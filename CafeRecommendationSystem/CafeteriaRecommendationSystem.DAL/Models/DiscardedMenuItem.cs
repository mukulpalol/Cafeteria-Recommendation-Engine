namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class DiscardedMenuItem
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public virtual ICollection<DiscardedMenuItemFeedback> DiscardedMenuItemFeedbacks { get; set; } = new List<DiscardedMenuItemFeedback>();
    }
}
