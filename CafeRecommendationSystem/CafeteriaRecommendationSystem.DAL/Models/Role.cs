namespace CafeteriaRecommendationSystem.DAL.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }

        public bool HasPermission(string permissionName)
        {
            return Permissions?.Any(p => p.Name == permissionName) ?? false;
        }
    }
}
