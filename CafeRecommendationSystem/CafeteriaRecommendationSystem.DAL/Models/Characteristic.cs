namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class Characteristic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MenuItemCharacteristic> MenuItemCharacteristics { get; set; } = new List<MenuItemCharacteristic>();
        public virtual ICollection<UserPreference> UserPreferences { get; set; } = new List<UserPreference>();
    }
}
