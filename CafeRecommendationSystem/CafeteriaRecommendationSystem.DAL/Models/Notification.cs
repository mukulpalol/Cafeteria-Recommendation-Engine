namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; } = null!;
        public int NotificationTypeId { get; set; }
        public DateTime Date { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual NotificationType NotificationType { get; set; } = null!;
    }
}
