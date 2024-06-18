namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; } = null!;
        public DateTime Date { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
