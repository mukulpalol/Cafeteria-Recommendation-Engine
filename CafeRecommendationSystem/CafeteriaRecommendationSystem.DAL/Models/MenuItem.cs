namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal SentimentScore { get; set; }
        public string? GeneralSentiment { get; set; }
        public int TypeId { get; set; }
        public virtual MenuItemType Type { get; set; } = null!;
        public int AvailabilityStatusId { get; set; }
        public virtual AvailabilityStatus AvailabilityStatus { get; set; } = null!;
        public virtual ICollection<DiscardedMenuItem> DiscardedMenuItems { get; set; } = new List<DiscardedMenuItem>();
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public virtual ICollection<Recommendation> Recommendations { get; set; } = new List<Recommendation>();
        public virtual ICollection<Selection> Selections { get; set; } = new List<Selection>();
    }
}
