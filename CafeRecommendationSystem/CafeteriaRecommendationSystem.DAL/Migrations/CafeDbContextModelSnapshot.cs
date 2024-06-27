﻿// <auto-generated />
using System;
using CafeteriaRecommendationSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CafeteriaRecommendationSystem.DAL.Migrations
{
    [DbContext(typeof(CafeDbContext))]
    partial class CafeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.AvailabilityStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("AvailabilityStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "Available"
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "Unavailable"
                        },
                        new
                        {
                            Id = 3,
                            StatusName = "Deleted"
                        },
                        new
                        {
                            Id = 4,
                            StatusName = "OutOfStock"
                        },
                        new
                        {
                            Id = 5,
                            StatusName = "OnHold"
                        });
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int")
                        .HasColumnName("MenuItemID");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Feedback", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "Delicious dosa!",
                            Date = new DateTime(2024, 6, 12, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9524),
                            MenuItemId = 1,
                            Rating = 4,
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            Comment = "Best biryani ever!",
                            Date = new DateTime(2024, 6, 14, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9539),
                            MenuItemId = 8,
                            Rating = 5,
                            UserId = 5
                        },
                        new
                        {
                            Id = 3,
                            Comment = "Poha was okay.",
                            Date = new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9540),
                            MenuItemId = 3,
                            Rating = 3,
                            UserId = 7
                        },
                        new
                        {
                            Id = 4,
                            Comment = "Paneer masala was tasty.",
                            Date = new DateTime(2024, 6, 16, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9541),
                            MenuItemId = 4,
                            Rating = 4,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Comment = "Amazing butter chicken!",
                            Date = new DateTime(2024, 6, 27, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9543),
                            MenuItemId = 11,
                            Rating = 5,
                            UserId = 6
                        },
                        new
                        {
                            Id = 6,
                            Comment = "Idli was soft and tasty.",
                            Date = new DateTime(2024, 6, 13, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9543),
                            MenuItemId = 2,
                            Rating = 4,
                            UserId = 8
                        },
                        new
                        {
                            Id = 7,
                            Comment = "Chole bhature was too spicy.",
                            Date = new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9544),
                            MenuItemId = 7,
                            Rating = 3,
                            UserId = 9
                        },
                        new
                        {
                            Id = 8,
                            Comment = "Dal tadka was too salty.",
                            Date = new DateTime(2024, 6, 16, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9546),
                            MenuItemId = 10,
                            Rating = 2,
                            UserId = 10
                        },
                        new
                        {
                            Id = 9,
                            Comment = "Rajma chawal was good.",
                            Date = new DateTime(2024, 6, 14, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9547),
                            MenuItemId = 5,
                            Rating = 4,
                            UserId = 3
                        },
                        new
                        {
                            Id = 10,
                            Comment = "Loved the veg thali!",
                            Date = new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9552),
                            MenuItemId = 6,
                            Rating = 5,
                            UserId = 4
                        },
                        new
                        {
                            Id = 11,
                            Comment = "Dosa was cold.",
                            Date = new DateTime(2024, 6, 13, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9553),
                            MenuItemId = 1,
                            Rating = 3,
                            UserId = 5
                        },
                        new
                        {
                            Id = 12,
                            Comment = "Biryani had good flavors.",
                            Date = new DateTime(2024, 6, 14, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9554),
                            MenuItemId = 8,
                            Rating = 4,
                            UserId = 6
                        },
                        new
                        {
                            Id = 13,
                            Comment = "Poha was excellent!",
                            Date = new DateTime(2024, 6, 16, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9555),
                            MenuItemId = 3,
                            Rating = 5,
                            UserId = 7
                        },
                        new
                        {
                            Id = 14,
                            Comment = "Paneer masala was too oily.",
                            Date = new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9558),
                            MenuItemId = 4,
                            Rating = 2,
                            UserId = 8
                        },
                        new
                        {
                            Id = 15,
                            Comment = "Butter chicken was average.",
                            Date = new DateTime(2024, 6, 27, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9559),
                            MenuItemId = 11,
                            Rating = 3,
                            UserId = 9
                        },
                        new
                        {
                            Id = 16,
                            Comment = "Idli sambar was perfect.",
                            Date = new DateTime(2024, 6, 12, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9560),
                            MenuItemId = 2,
                            Rating = 4,
                            UserId = 10
                        },
                        new
                        {
                            Id = 17,
                            Comment = "Chole bhature were amazing!",
                            Date = new DateTime(2024, 6, 14, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9561),
                            MenuItemId = 7,
                            Rating = 5,
                            UserId = 3
                        },
                        new
                        {
                            Id = 18,
                            Comment = "Dal tadka was flavorful.",
                            Date = new DateTime(2024, 6, 16, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9562),
                            MenuItemId = 10,
                            Rating = 3,
                            UserId = 4
                        },
                        new
                        {
                            Id = 19,
                            Comment = "Rajma chawal was delicious.",
                            Date = new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9563),
                            MenuItemId = 5,
                            Rating = 4,
                            UserId = 5
                        },
                        new
                        {
                            Id = 20,
                            Comment = "Veg thali was satisfying.",
                            Date = new DateTime(2024, 6, 16, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9564),
                            MenuItemId = 6,
                            Rating = 5,
                            UserId = 6
                        },
                        new
                        {
                            Id = 21,
                            Comment = "Dosa was okay.",
                            Date = new DateTime(2024, 6, 13, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9564),
                            MenuItemId = 1,
                            Rating = 3,
                            UserId = 7
                        },
                        new
                        {
                            Id = 22,
                            Comment = "Biryani was spicy and tasty.",
                            Date = new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9566),
                            MenuItemId = 8,
                            Rating = 4,
                            UserId = 8
                        },
                        new
                        {
                            Id = 23,
                            Comment = "Poha was excellent as always.",
                            Date = new DateTime(2024, 6, 16, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9567),
                            MenuItemId = 3,
                            Rating = 5,
                            UserId = 9
                        },
                        new
                        {
                            Id = 24,
                            Comment = "Paneer masala was too salty.",
                            Date = new DateTime(2024, 6, 14, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9568),
                            MenuItemId = 4,
                            Rating = 2,
                            UserId = 10
                        },
                        new
                        {
                            Id = 25,
                            Comment = "Butter chicken was good.",
                            Date = new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9568),
                            MenuItemId = 11,
                            Rating = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailabilityStatusId")
                        .HasColumnType("int")
                        .HasColumnName("AvailabilityStatusID");

                    b.Property<string>("GeneralSentiment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("SentimentScore")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("TypeID");

                    b.HasKey("Id");

                    b.HasIndex("AvailabilityStatusId");

                    b.HasIndex("TypeId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            AvailabilityStatusId = 1,
                            GeneralSentiment = "good",
                            Name = "Rajma Chawal",
                            Price = 40.00m,
                            SentimentScore = 0.49m,
                            TypeId = 2
                        },
                        new
                        {
                            Id = 6,
                            AvailabilityStatusId = 1,
                            GeneralSentiment = "good",
                            Name = "Veg Thali",
                            Price = 60.00m,
                            SentimentScore = 0.49m,
                            TypeId = 2
                        },
                        new
                        {
                            Id = 7,
                            AvailabilityStatusId = 1,
                            GeneralSentiment = "good",
                            Name = "Chole Bhature",
                            Price = 45.00m,
                            SentimentScore = 0.49m,
                            TypeId = 2
                        },
                        new
                        {
                            Id = 8,
                            AvailabilityStatusId = 1,
                            GeneralSentiment = "good",
                            Name = "Chicken Biryani",
                            Price = 70.00m,
                            SentimentScore = 0.49m,
                            TypeId = 3
                        },
                        new
                        {
                            Id = 9,
                            AvailabilityStatusId = 1,
                            GeneralSentiment = "good",
                            Name = "Roti Sabzi",
                            Price = 35.00m,
                            SentimentScore = 0.49m,
                            TypeId = 3
                        },
                        new
                        {
                            Id = 10,
                            AvailabilityStatusId = 1,
                            GeneralSentiment = "good",
                            Name = "Dal Tadka",
                            Price = 30.00m,
                            SentimentScore = 0.49m,
                            TypeId = 3
                        },
                        new
                        {
                            Id = 11,
                            AvailabilityStatusId = 1,
                            GeneralSentiment = "good",
                            Name = "Butter Chicken",
                            Price = 80.00m,
                            SentimentScore = 0.49m,
                            TypeId = 3
                        },
                        new
                        {
                            Id = 12,
                            AvailabilityStatusId = 1,
                            GeneralSentiment = "good",
                            Name = "Veg Biryani",
                            Price = 60.00m,
                            SentimentScore = 0.49m,
                            TypeId = 3
                        });
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.MenuItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("MenuItemTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeName = "Breakfast"
                        },
                        new
                        {
                            Id = 2,
                            TypeName = "Lunch"
                        },
                        new
                        {
                            Id = 3,
                            TypeName = "Dinner"
                        },
                        new
                        {
                            Id = 4,
                            TypeName = "Beverage"
                        });
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("NotificationTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("NotificationTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.NotificationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("NotificationTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "NewFoodItemAdded"
                        },
                        new
                        {
                            Id = 2,
                            Name = "FoodItemRemoved"
                        },
                        new
                        {
                            Id = 3,
                            Name = "FoodItemPriceUpdated"
                        },
                        new
                        {
                            Id = 4,
                            Name = "FoodItemAvailabilityUpdated"
                        },
                        new
                        {
                            Id = 5,
                            Name = "FoodItemVoting"
                        },
                        new
                        {
                            Id = 6,
                            Name = "FinalMenu"
                        });
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.Recommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsFinalised")
                        .HasColumnType("bit");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int")
                        .HasColumnName("MenuItemID");

                    b.Property<DateTime>("RecommendationDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.ToTable("Recommendations");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Chef"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "Employee"
                        });
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.Selection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int")
                        .HasColumnName("MenuItemID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Selections");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@email.com",
                            EmployeeId = "ITTV/EMP/0000",
                            Name = "admin",
                            Password = "Password@1",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            Email = "johndoe@email.com",
                            EmployeeId = "ITTV/EMP/0004",
                            Name = "John Doe",
                            Password = "Password@1",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 5,
                            Email = "janesmith@email.com",
                            EmployeeId = "ITTV/EMP/0005",
                            Name = "Jane Smith",
                            Password = "Password@1",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 6,
                            Email = "rajpatel@email.com",
                            EmployeeId = "ITTV/EMP/0006",
                            Name = "Raj Patel",
                            Password = "Password@1",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 7,
                            Email = "anitagupta@email.com",
                            EmployeeId = "ITTV/EMP/0007",
                            Name = "Anita Gupta",
                            Password = "Password@1",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 8,
                            Email = "vikramsingh@email.com",
                            EmployeeId = "ITTV/EMP/0008",
                            Name = "Vikram Singh",
                            Password = "Password@1",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 9,
                            Email = "priyakumar@email.com",
                            EmployeeId = "ITTV/EMP/0009",
                            Name = "Priya Kumar",
                            Password = "Password@1",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 10,
                            Email = "alokverma@email.com",
                            EmployeeId = "ITTV/EMP/0010",
                            Name = "Alok Verma",
                            Password = "Password@1",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 11,
                            Email = "sunitarao@email.com",
                            EmployeeId = "ITTV/EMP/0011",
                            Name = "Sunita Rao",
                            Password = "Password@1",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 12,
                            Email = "karandesai@email.com",
                            EmployeeId = "ITTV/EMP/0012",
                            Name = "Karan Desai",
                            Password = "Password@1",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 13,
                            Email = "meerasharma@email.com",
                            EmployeeId = "ITTV/EMP/0013",
                            Name = "Meera Sharma",
                            Password = "Password@1",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.Feedback", b =>
                {
                    b.HasOne("CafeteriaRecommendationSystem.DAL.Models.MenuItem", "MenuItem")
                        .WithMany("Feedbacks")
                        .HasForeignKey("MenuItemId")
                        .IsRequired()
                        .HasConstraintName("FK_Feedback_MenuItems");

                    b.HasOne("CafeteriaRecommendationSystem.DAL.Models.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Feedback_Users");

                    b.Navigation("MenuItem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.MenuItem", b =>
                {
                    b.HasOne("CafeteriaRecommendationSystem.DAL.Models.AvailabilityStatus", "AvailabilityStatus")
                        .WithMany("MenuItems")
                        .HasForeignKey("AvailabilityStatusId")
                        .IsRequired()
                        .HasConstraintName("FK_MenuItems_AvailabilityStatus");

                    b.HasOne("CafeteriaRecommendationSystem.DAL.Models.MenuItemType", "Type")
                        .WithMany("MenuItems")
                        .HasForeignKey("TypeId")
                        .IsRequired()
                        .HasConstraintName("FK_MenuItems_MenuItemTypes");

                    b.Navigation("AvailabilityStatus");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.Notification", b =>
                {
                    b.HasOne("CafeteriaRecommendationSystem.DAL.Models.NotificationType", "NotificationType")
                        .WithMany("Notifications")
                        .HasForeignKey("NotificationTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_Notifications_NotificationTypes");

                    b.HasOne("CafeteriaRecommendationSystem.DAL.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Notifications_Users");

                    b.Navigation("NotificationType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.Recommendation", b =>
                {
                    b.HasOne("CafeteriaRecommendationSystem.DAL.Models.MenuItem", "MenuItem")
                        .WithMany("Recommendations")
                        .HasForeignKey("MenuItemId")
                        .IsRequired()
                        .HasConstraintName("FK_Recommendations_MenuItems");

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.Selection", b =>
                {
                    b.HasOne("CafeteriaRecommendationSystem.DAL.Models.MenuItem", "MenuItem")
                        .WithMany("Selections")
                        .HasForeignKey("MenuItemId")
                        .IsRequired()
                        .HasConstraintName("FK_Selections_MenuItems");

                    b.HasOne("CafeteriaRecommendationSystem.DAL.Models.User", "User")
                        .WithMany("Selections")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Selections_Users");

                    b.Navigation("MenuItem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.User", b =>
                {
                    b.HasOne("CafeteriaRecommendationSystem.DAL.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_Users_Roles");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.AvailabilityStatus", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.MenuItem", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Recommendations");

                    b.Navigation("Selections");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.MenuItemType", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.NotificationType", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CafeteriaRecommendationSystem.DAL.Models.User", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Notifications");

                    b.Navigation("Selections");
                });
#pragma warning restore 612, 618
        }
    }
}
