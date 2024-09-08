using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeteriaRecommendationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedSeedDataForTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "ID", "AvailabilityStatusID", "IsDeleted", "Name", "Price", "TypeID" },
                values: new object[,]
                {
                    { 5, 1, false, "Rajma Chawal", 40.00m, 2 },
                    { 6, 1, false, "Veg Thali", 60.00m, 2 },
                    { 7, 1, false, "Chole Bhature", 45.00m, 2 },
                    { 8, 1, false, "Chicken Biryani", 70.00m, 3 },
                    { 9, 1, false, "Roti Sabzi", 35.00m, 3 },
                    { 10, 1, false, "Dal Tadka", 30.00m, 3 },
                    { 11, 1, false, "Butter Chicken", 80.00m, 3 },
                    { 12, 1, false, "Veg Biryani", 60.00m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "EmployeeId", "Name", "Password", "RoleID" },
                values: new object[,]
                {
                    { 4, "johndoe@email.com", "ITTV/EMP/0004", "John Doe", "Password@1", 3 },
                    { 5, "janesmith@email.com", "ITTV/EMP/0005", "Jane Smith", "Password@1", 3 },
                    { 6, "rajpatel@email.com", "ITTV/EMP/0006", "Raj Patel", "Password@1", 2 },
                    { 7, "anitagupta@email.com", "ITTV/EMP/0007", "Anita Gupta", "Password@1", 3 },
                    { 8, "vikramsingh@email.com", "ITTV/EMP/0008", "Vikram Singh", "Password@1", 3 },
                    { 9, "priyakumar@email.com", "ITTV/EMP/0009", "Priya Kumar", "Password@1", 2 },
                    { 10, "alokverma@email.com", "ITTV/EMP/0010", "Alok Verma", "Password@1", 3 },
                    { 11, "sunitarao@email.com", "ITTV/EMP/0011", "Sunita Rao", "Password@1", 3 },
                    { 12, "karandesai@email.com", "ITTV/EMP/0012", "Karan Desai", "Password@1", 2 },
                    { 13, "meerasharma@email.com", "ITTV/EMP/0013", "Meera Sharma", "Password@1", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 13);
        }
    }
}
