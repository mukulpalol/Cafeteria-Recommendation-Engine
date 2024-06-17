namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class MenuType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
