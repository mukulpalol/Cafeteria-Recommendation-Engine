﻿namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
