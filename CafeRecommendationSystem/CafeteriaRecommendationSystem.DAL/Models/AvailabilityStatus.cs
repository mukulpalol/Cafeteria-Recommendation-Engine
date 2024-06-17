﻿namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class AvailabilityStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
