using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeteriaRecommendationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AvailabilityStatus",
                keyColumn: "ID",
                keyValue: 3,
                column: "StatusName",
                value: "Deleted");

            migrationBuilder.InsertData(
                table: "AvailabilityStatus",
                columns: new[] { "ID", "Description", "StatusName" },
                values: new object[,]
                {
                    { 4, null, "OutOfStock" },
                    { 5, null, "OnHold" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AvailabilityStatus",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AvailabilityStatus",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AvailabilityStatus",
                keyColumn: "ID",
                keyValue: 3,
                column: "StatusName",
                value: "PermanentlyDeleted");
        }
    }
}
