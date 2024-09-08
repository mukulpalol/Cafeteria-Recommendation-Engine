using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaRecommendationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedTablesForDiscardedMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscardedMenuItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscardedMenuItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DiscardedMenuItem_MenuItems",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DiscardedMenyItemFeedback",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscardedMenuItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Feedback = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscardedMenyItemFeedback", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DiscardedMenuItemFeedback_DiscardedMenuItems",
                        column: x => x.UserId,
                        principalTable: "DiscardedMenuItem",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DiscardedMenuItemFeedback_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "AvailabilityStatus",
                columns: new[] { "ID", "Description", "StatusName" },
                values: new object[] { 6, null, "Discarded" });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 17, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3482));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 19, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 6, 21, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 7, 2, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3510));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 6, 18, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3521));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3522));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 6, 21, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 6, 19, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3524));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3525));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 6, 18, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3526));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2024, 6, 19, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2024, 6, 21, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3528));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2024, 7, 2, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3529));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2024, 6, 17, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3530));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2024, 6, 19, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2024, 6, 21, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 6, 21, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3534));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2024, 6, 18, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2024, 6, 21, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3537));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2024, 6, 19, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3537));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 57, 59, 560, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.CreateIndex(
                name: "IX_DiscardedMenuItem_MenuItemId",
                table: "DiscardedMenuItem",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscardedMenyItemFeedback_UserId",
                table: "DiscardedMenyItemFeedback",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscardedMenyItemFeedback");

            migrationBuilder.DropTable(
                name: "DiscardedMenuItem");

            migrationBuilder.DeleteData(
                table: "AvailabilityStatus",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 16, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 18, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 19, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 7, 1, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9319));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 6, 17, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9333));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 6, 19, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 6, 18, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 6, 19, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 6, 17, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2024, 6, 18, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 6, 19, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2024, 7, 1, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2024, 6, 16, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2024, 6, 18, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9356));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2024, 6, 19, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2024, 6, 17, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9360));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2024, 6, 19, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9362));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2024, 6, 20, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2024, 6, 18, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2024, 6, 19, 21, 25, 22, 789, DateTimeKind.Local).AddTicks(9366));
        }
    }
}
