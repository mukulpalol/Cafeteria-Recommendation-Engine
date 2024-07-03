namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class UserPreference
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CharacteristicId { get; set; }
        public virtual User User { get; set; }
        public virtual Characteristic Characteristic { get; set; }
    }
}
