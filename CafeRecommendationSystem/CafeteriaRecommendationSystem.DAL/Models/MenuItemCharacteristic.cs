namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class MenuItemCharacteristic
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public int CharacteristicId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public virtual Characteristic Characteristic { get; set; }
    }
}
