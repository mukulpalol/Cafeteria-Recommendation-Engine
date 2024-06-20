using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeteriaRecommendationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedSeedDataForFeedbackTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "ID", "Comment", "Date", "MenuItemID", "Rating", "UserID" },
                values: new object[,]
                {
                    { 1, "Delicious dosa!", new DateTime(2024, 6, 15, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(5986), 1, 4, 3 },
                    { 2, "Best biryani ever!", new DateTime(2024, 6, 17, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6001), 8, 5, 5 },
                    { 3, "Poha was okay.", new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6002), 3, 3, 7 },
                    { 4, "Paneer masala was tasty.", new DateTime(2024, 6, 19, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6003), 4, 4, 4 },
                    { 5, "Amazing butter chicken!", new DateTime(2024, 6, 20, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6004), 11, 5, 6 },
                    { 6, "Idli was soft and tasty.", new DateTime(2024, 6, 16, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6005), 2, 4, 8 },
                    { 7, "Chole bhature was too spicy.", new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6006), 7, 3, 9 },
                    { 8, "Dal tadka was too salty.", new DateTime(2024, 6, 19, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6007), 10, 2, 10 },
                    { 9, "Rajma chawal was good.", new DateTime(2024, 6, 17, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6008), 5, 4, 3 },
                    { 10, "Loved the veg thali!", new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6009), 6, 5, 4 },
                    { 11, "Dosa was cold.", new DateTime(2024, 6, 16, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6010), 1, 3, 5 },
                    { 12, "Biryani had good flavors.", new DateTime(2024, 6, 17, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6011), 8, 4, 6 },
                    { 13, "Poha was excellent!", new DateTime(2024, 6, 19, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6012), 3, 5, 7 },
                    { 14, "Paneer masala was too oily.", new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6013), 4, 2, 8 },
                    { 15, "Butter chicken was average.", new DateTime(2024, 6, 20, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6014), 11, 3, 9 },
                    { 16, "Idli sambar was perfect.", new DateTime(2024, 6, 15, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6015), 2, 4, 10 },
                    { 17, "Chole bhature were amazing!", new DateTime(2024, 6, 17, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6016), 7, 5, 3 },
                    { 18, "Dal tadka was flavorful.", new DateTime(2024, 6, 19, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6017), 10, 3, 4 },
                    { 19, "Rajma chawal was delicious.", new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6018), 5, 4, 5 },
                    { 20, "Veg thali was satisfying.", new DateTime(2024, 6, 19, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6019), 6, 5, 6 },
                    { 21, "Dosa was okay.", new DateTime(2024, 6, 16, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6020), 1, 3, 7 },
                    { 22, "Biryani was spicy and tasty.", new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6021), 8, 4, 8 },
                    { 23, "Poha was excellent as always.", new DateTime(2024, 6, 19, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6022), 3, 5, 9 },
                    { 24, "Paneer masala was too salty.", new DateTime(2024, 6, 17, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6023), 4, 2, 10 },
                    { 25, "Butter chicken was good.", new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6024), 11, 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25);
        }
    }
}
