using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeteriaRecommendationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addeddTablesForPreference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characteristic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemCharacteristic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemID = table.Column<int>(type: "int", nullable: false),
                    CharacteristicID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemCharacteristic", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MenuItemCharacteristic_Characteristic",
                        column: x => x.CharacteristicID,
                        principalTable: "Characteristic",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MenuItemCharacteristic_MenuItem",
                        column: x => x.MenuItemID,
                        principalTable: "MenuItems",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserPreference",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CharacteristicID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreference", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserPreference_Characteristic",
                        column: x => x.CharacteristicID,
                        principalTable: "Characteristic",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserPreference_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Characteristic",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Vegetarian" },
                    { 2, "Non-Vegetarian" },
                    { 3, "Eggetarian" },
                    { 4, "Spicy" },
                    { 5, "Sweet" },
                    { 6, "NorthIndian" },
                    { 7, "SouthIndian" },
                    { 8, "FastFood" },
                    { 9, "Dairy" }
                });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 18, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(970), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(986), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(987), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 22, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(988), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(999), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1009), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1010), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 22, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1010), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1011), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1012), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1013), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1014), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 22, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1015), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1016), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1017), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 18, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1018), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1019), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 22, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1020), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1020), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 22, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1021), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1022), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1024), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 22, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1025), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1026), 5 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1027), 5 });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemCharacteristic_CharacteristicID",
                table: "MenuItemCharacteristic",
                column: "CharacteristicID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemCharacteristic_MenuItemID",
                table: "MenuItemCharacteristic",
                column: "MenuItemID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreference_CharacteristicID",
                table: "UserPreference",
                column: "CharacteristicID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreference_UserID",
                table: "UserPreference",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItemCharacteristic");

            migrationBuilder.DropTable(
                name: "UserPreference");

            migrationBuilder.DropTable(
                name: "Characteristic");

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 18, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5413), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5459), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5466), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 22, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5476), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 7, 3, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5477), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5478), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5479), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 22, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5484), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5493), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5495), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5496), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5497), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 22, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5499), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5500), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 7, 3, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5501), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 18, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5502), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5503), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 22, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5504), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5505), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 22, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5506), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5507), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5509), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 22, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5510), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5511), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 21, 2, 29, 30, 851, DateTimeKind.Local).AddTicks(5515), 0 });
        }
    }
}
