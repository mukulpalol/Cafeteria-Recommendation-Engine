using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaRecommendationSystem.DAL
{
    public class CafeDbContext : DbContext
    {
        public DbSet<AvailabilityStatus> AvailabilityStatuses { get; set; }
        public DbSet<DiscardedMenuItem> DiscardedMenuItems { get; set; }
        public DbSet<DiscardedMenuItemFeedback> DiscardedMenuItemFeedbacks { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<MenuItemType> MenuItemTypes { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationType> NotificationTypes { get; set; }
        public virtual DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public virtual DbSet<Selection> Selections { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(AppConstants.ConnectionString);

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

            modelBuilder.Entity<DiscardedMenuItem>(entity =>
            {
                entity.ToTable("DiscardedMenuItem");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.HasOne(d => d.MenuItem).WithMany(p => p.DiscardedMenuItems)
                    .HasForeignKey(d => d.MenuItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiscardedMenuItem_MenuItems");
            });

            modelBuilder.Entity<DiscardedMenuItemFeedback>(entity =>
            {
                entity.ToTable("DiscardedMenyItemFeedback");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.Feedback)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.User).WithMany(p => p.DiscardedMenuItemFeedbacks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiscardedMenuItemFeedback_Users");

                entity.HasOne(d => d.DiscardedMenuItem).WithMany(p => p.DiscardedMenuItemFeedbacks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiscardedMenuItemFeedback_DiscardedMenuItems");
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
                entity.Property(e => e.SentimentScore).HasColumnType("decimal(18, 2)");
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
                entity.Property(e => e.IsDelivered).HasColumnType("bit");

                entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_Users");

                entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.NotificationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_NotificationTypes");
            });

            modelBuilder.Entity<NotificationType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(30).IsUnicode(false);
            });

            modelBuilder.Entity<Recommendation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.RecommendationDate).HasColumnType("date");
                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");
                entity.Property(e => e.IsFinalised).HasColumnType("bit");

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
                new AvailabilityStatus { Id = 1, StatusName = "Available" },
                new AvailabilityStatus { Id = 2, StatusName = "Unavailable" },
                new AvailabilityStatus { Id = 3, StatusName = "Deleted" },
                new AvailabilityStatus { Id = 4, StatusName = "OutOfStock" },
                new AvailabilityStatus { Id = 5, StatusName = "OnHold" },
                new AvailabilityStatus { Id = 6, StatusName = "Discarded" }
                );

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { Id = 1, UserId = 3, MenuItemId = 1, Rating = 4, Comment = "Delicious dosa!", Date = DateTime.Now.AddDays(-15) },
                new Feedback { Id = 2, UserId = 5, MenuItemId = 8, Rating = 5, Comment = "Best biryani ever!", Date = DateTime.Now.AddDays(-13) },
                new Feedback { Id = 3, UserId = 7, MenuItemId = 3, Rating = 3, Comment = "Poha was okay.", Date = DateTime.Now.AddDays(-12) },
                new Feedback { Id = 4, UserId = 4, MenuItemId = 4, Rating = 4, Comment = "Paneer masala was tasty.", Date = DateTime.Now.AddDays(-11) },
                new Feedback { Id = 5, UserId = 6, MenuItemId = 11, Rating = 5, Comment = "Amazing butter chicken!", Date = DateTime.Now },
                new Feedback { Id = 6, UserId = 8, MenuItemId = 2, Rating = 4, Comment = "Idli was soft and tasty.", Date = DateTime.Now.AddDays(-14) },
                new Feedback { Id = 7, UserId = 9, MenuItemId = 7, Rating = 3, Comment = "Chole bhature was too spicy.", Date = DateTime.Now.AddDays(-12) },
                new Feedback { Id = 8, UserId = 10, MenuItemId = 10, Rating = 2, Comment = "Dal tadka was too salty.", Date = DateTime.Now.AddDays(-11) },
                new Feedback { Id = 9, UserId = 3, MenuItemId = 5, Rating = 4, Comment = "Rajma chawal was good.", Date = DateTime.Now.AddDays(-13) },
                new Feedback { Id = 10, UserId = 4, MenuItemId = 6, Rating = 5, Comment = "Loved the veg thali!", Date = DateTime.Now.AddDays(-12) },
                new Feedback { Id = 11, UserId = 5, MenuItemId = 1, Rating = 3, Comment = "Dosa was cold.", Date = DateTime.Now.AddDays(-14) },
                new Feedback { Id = 12, UserId = 6, MenuItemId = 8, Rating = 4, Comment = "Biryani had good flavors.", Date = DateTime.Now.AddDays(-13) },
                new Feedback { Id = 13, UserId = 7, MenuItemId = 3, Rating = 5, Comment = "Poha was excellent!", Date = DateTime.Now.AddDays(-11) },
                new Feedback { Id = 14, UserId = 8, MenuItemId = 4, Rating = 2, Comment = "Paneer masala was too oily.", Date = DateTime.Now.AddDays(-12) },
                new Feedback { Id = 15, UserId = 9, MenuItemId = 11, Rating = 3, Comment = "Butter chicken was average.", Date = DateTime.Now },
                new Feedback { Id = 16, UserId = 10, MenuItemId = 2, Rating = 4, Comment = "Idli sambar was perfect.", Date = DateTime.Now.AddDays(-15) },
                new Feedback { Id = 17, UserId = 3, MenuItemId = 7, Rating = 5, Comment = "Chole bhature were amazing!", Date = DateTime.Now.AddDays(-13) },
                new Feedback { Id = 18, UserId = 4, MenuItemId = 10, Rating = 3, Comment = "Dal tadka was flavorful.", Date = DateTime.Now.AddDays(-11) },
                new Feedback { Id = 19, UserId = 5, MenuItemId = 5, Rating = 4, Comment = "Rajma chawal was delicious.", Date = DateTime.Now.AddDays(-12) },
                new Feedback { Id = 20, UserId = 6, MenuItemId = 6, Rating = 5, Comment = "Veg thali was satisfying.", Date = DateTime.Now.AddDays(-11) },
                new Feedback { Id = 21, UserId = 7, MenuItemId = 1, Rating = 3, Comment = "Dosa was okay.", Date = DateTime.Now.AddDays(-14) },
                new Feedback { Id = 22, UserId = 8, MenuItemId = 8, Rating = 4, Comment = "Biryani was spicy and tasty.", Date = DateTime.Now.AddDays(-12) },
                new Feedback { Id = 23, UserId = 9, MenuItemId = 3, Rating = 5, Comment = "Poha was excellent as always.", Date = DateTime.Now.AddDays(-11) },
                new Feedback { Id = 24, UserId = 10, MenuItemId = 4, Rating = 2, Comment = "Paneer masala was too salty.", Date = DateTime.Now.AddDays(-13) },
                new Feedback { Id = 25, UserId = 3, MenuItemId = 11, Rating = 3, Comment = "Butter chicken was good.", Date = DateTime.Now.AddDays(-12) }
       );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 5, Name = "Rajma Chawal", Price = 40.00m, TypeId = 2, AvailabilityStatusId = 1, SentimentScore = 0.49m, GeneralSentiment = "good" },
                new MenuItem { Id = 6, Name = "Veg Thali", Price = 60.00m, TypeId = 2, AvailabilityStatusId = 1, SentimentScore = 0.49m, GeneralSentiment = "good" },
                new MenuItem { Id = 7, Name = "Chole Bhature", Price = 45.00m, TypeId = 2, AvailabilityStatusId = 1, SentimentScore = 0.49m, GeneralSentiment = "good" },
                new MenuItem { Id = 8, Name = "Chicken Biryani", Price = 70.00m, TypeId = 3, AvailabilityStatusId = 1, SentimentScore = 0.49m, GeneralSentiment = "good" },
                new MenuItem { Id = 9, Name = "Roti Sabzi", Price = 35.00m, TypeId = 3, AvailabilityStatusId = 1, SentimentScore = 0.49m, GeneralSentiment = "good" },
                new MenuItem { Id = 10, Name = "Dal Tadka", Price = 30.00m, TypeId = 3, AvailabilityStatusId = 1, SentimentScore = 0.49m, GeneralSentiment = "good" },
                new MenuItem { Id = 11, Name = "Butter Chicken", Price = 80.00m, TypeId = 3, AvailabilityStatusId = 1, SentimentScore = 0.49m, GeneralSentiment = "good" },
                new MenuItem { Id = 12, Name = "Veg Biryani", Price = 60.00m, TypeId = 3, AvailabilityStatusId = 1, SentimentScore = 0.49m, GeneralSentiment = "good" }
            );

            modelBuilder.Entity<MenuItemType>().HasData(
                new MenuItemType { Id = 1, TypeName = "Breakfast" },
                new MenuItemType { Id = 2, TypeName = "Lunch" },
                new MenuItemType { Id = 3, TypeName = "Dinner" },
                new MenuItemType { Id = 4, TypeName = "Beverage" }
                );

            modelBuilder.Entity<NotificationType>().HasData(
                new NotificationType { Id = 1, Name = "NewFoodItemAdded" },
                new NotificationType { Id = 2, Name = "FoodItemRemoved" },
                new NotificationType { Id = 3, Name = "FoodItemPriceUpdated" },
                new NotificationType { Id = 4, Name = "FoodItemAvailabilityUpdated" },
                new NotificationType { Id = 5, Name = "MenuRolledOut" },
                new NotificationType { Id = 6, Name = "MenuFinalised" }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "Chef" },
                new Role { Id = 3, RoleName = "Employee" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "admin", Email = "admin@email.com", EmployeeId = "ITTV/EMP/0000", Password = "Password@1", RoleId = 1 },
                new User { Id = 4, Name = "John Doe", Email = "johndoe@email.com", EmployeeId = "ITTV/EMP/0004", Password = "Password@1", RoleId = 3 },
                new User { Id = 5, Name = "Jane Smith", Email = "janesmith@email.com", EmployeeId = "ITTV/EMP/0005", Password = "Password@1", RoleId = 3 },
                new User { Id = 6, Name = "Raj Patel", Email = "rajpatel@email.com", EmployeeId = "ITTV/EMP/0006", Password = "Password@1", RoleId = 2 },
                new User { Id = 7, Name = "Anita Gupta", Email = "anitagupta@email.com", EmployeeId = "ITTV/EMP/0007", Password = "Password@1", RoleId = 3 },
                new User { Id = 8, Name = "Vikram Singh", Email = "vikramsingh@email.com", EmployeeId = "ITTV/EMP/0008", Password = "Password@1", RoleId = 3 },
                new User { Id = 9, Name = "Priya Kumar", Email = "priyakumar@email.com", EmployeeId = "ITTV/EMP/0009", Password = "Password@1", RoleId = 2 },
                new User { Id = 10, Name = "Alok Verma", Email = "alokverma@email.com", EmployeeId = "ITTV/EMP/0010", Password = "Password@1", RoleId = 3 },
                new User { Id = 11, Name = "Sunita Rao", Email = "sunitarao@email.com", EmployeeId = "ITTV/EMP/0011", Password = "Password@1", RoleId = 3 },
                new User { Id = 12, Name = "Karan Desai", Email = "karandesai@email.com", EmployeeId = "ITTV/EMP/0012", Password = "Password@1", RoleId = 2 },
                new User { Id = 13, Name = "Meera Sharma", Email = "meerasharma@email.com", EmployeeId = "ITTV/EMP/0013", Password = "Password@1", RoleId = 3 }
                );
        }
    }
}
