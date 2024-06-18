﻿namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class MenuItemType
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = null!;
        public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
