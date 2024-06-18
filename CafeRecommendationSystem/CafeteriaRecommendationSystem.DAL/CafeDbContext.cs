using CafeteriaRecommendationSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaRecommendationSystem.DAL
{
    public class CafeDbContext : DbContext
    {
        public DbSet<AvailabilityStatus> AvailabilityStatuses { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<MenuItemType> MenuItemTypes { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public virtual DbSet<Selection> Selections { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=ITT-MUKUL-PA\\SQLEXPRESS;Database=CRS_Db;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvailabilityStatus>(entity =>
            {
                entity.ToTable("AvailabilityStatus");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.StatusName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.MenuItem).WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.MenuItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_MenuItems");

                entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Users");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.AvailabilityStatusId).HasColumnName("AvailabilityStatusID");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.AvailabilityStatus).WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.AvailabilityStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuItems_AvailabilityStatus");

                entity.HasOne(d => d.Type).WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuItems_MenuItemTypes");
            });

            modelBuilder.Entity<MenuItemType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.TypeName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_Users");
            });

            modelBuilder.Entity<Recommendation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.DateRecommended).HasColumnType("date");
                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");
                entity.Property(e => e.RecommendationScore).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MenuItem).WithMany(p => p.Recommendations)
                    .HasForeignKey(d => d.MenuItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recommendations_MenuItems");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Selection>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.MenuItem).WithMany(p => p.Selections)
                    .HasForeignKey(d => d.MenuItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Selections_MenuItems");

                entity.HasOne(d => d.User).WithMany(p => p.Selections)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Selections_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role).WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            modelBuilder.Entity<AvailabilityStatus>().HasData(
                new AvailabilityStatus { Id = 1, StatusName = "Available"},
                new AvailabilityStatus { Id = 2, StatusName = "Unavailable"},
                new AvailabilityStatus { Id = 3, StatusName = "PermanentlyDeleted"}
                );

            modelBuilder.Entity<MenuItemType>().HasData(
                new MenuItemType { Id = 1, TypeName = "Breakfast" },
                new MenuItemType { Id = 2, TypeName = "Lunch" },
                new MenuItemType { Id = 3, TypeName = "Dinner" }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "Chef" },
                new Role { Id = 3, RoleName = "Employee" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "admin", Email = "admin@email.com", EmployeeId = "ITTV/EMP/0000", Password = "Password@1", RoleId = 1 }
                );
        }
    }
}
