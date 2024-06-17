namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TypeId { get; set; }
        public virtual MenuType Type { get; set; }
        public int AvailabilityStatusId { get; set; }
        public virtual AvailabilityStatus AvailabilityStatus { get; set; }
        public bool IsDeleted { get; set; }
    }
}
