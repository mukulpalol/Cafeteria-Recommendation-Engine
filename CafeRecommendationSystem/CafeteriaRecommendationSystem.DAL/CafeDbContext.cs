using CafeteriaRecommendationSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaRecommendationSystem.DAL
{
    public class CafeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuType> MenuTypes { get; set; }
        public DbSet<AvailabilityStatus> AvailabilityStatuses { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=ITT-MUKUL-PA\\SQLEXPRESS;Database=CRS_Db;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Role>()
            .HasMany(r => r.Permissions)
            .WithMany(p => p.Roles)
            .UsingEntity(j => j.ToTable("RolePermissions"));

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Chef" },
                new Role { Id = 3, Name = "Employee" }
                );

            modelBuilder.Entity<Permission>().HasData(
                new Permission { Id = 1, Name = "AddMenuItem" },
                new Permission { Id = 2, Name = "GenerateReport" }
            );

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Permissions)
                .WithMany(p => p.Roles)
                .UsingEntity(j =>
                {
                    j.HasData(
                        new { RolesId = 1, PermissionsId = 1 },
                        new { RolesId = 1, PermissionsId = 2 },
                        new { RolesId = 2, PermissionsId = 1 }
                    );
                });

            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Type)
                .WithMany(t => t.MenuItems)
                .HasForeignKey(m => m.TypeId);

            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.AvailabilityStatus)
                .WithMany(a => a.MenuItems)
                .HasForeignKey(m => m.AvailabilityStatusId);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.MenuItem)
                .WithMany()
                .HasForeignKey(f => f.MenuItemId);
        }
    }
}
