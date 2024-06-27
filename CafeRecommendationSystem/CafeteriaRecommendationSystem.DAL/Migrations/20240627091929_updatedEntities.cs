using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaRecommendationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "DateRecommended",
                table: "Recommendations",
                newName: "RecommendationDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelivered",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 12, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 14, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9539));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 6, 16, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 6, 27, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 6, 13, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 6, 16, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 6, 14, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 6, 13, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2024, 6, 14, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2024, 6, 16, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2024, 6, 27, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9559));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2024, 6, 12, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2024, 6, 14, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9561));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2024, 6, 16, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9563));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 6, 16, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9564));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2024, 6, 13, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9564));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9566));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2024, 6, 16, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9567));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2024, 6, 14, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2024, 6, 15, 14, 49, 28, 983, DateTimeKind.Local).AddTicks(9568));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelivered",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "RecommendationDate",
                table: "Recommendations",
                newName: "DateRecommended");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 6, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 8, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 9, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 6, 10, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 6, 21, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 6, 7, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1511));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 6, 9, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 6, 10, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 6, 8, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 6, 9, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 6, 7, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2024, 6, 8, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1537));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2024, 6, 10, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 6, 9, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2024, 6, 21, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2024, 6, 6, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2024, 6, 8, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1547));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2024, 6, 10, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2024, 6, 9, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 6, 10, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2024, 6, 7, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2024, 6, 9, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2024, 6, 10, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2024, 6, 8, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2024, 6, 9, 2, 3, 7, 100, DateTimeKind.Local).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 6,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 7,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 8,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 9,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 10,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 11,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 12,
                column: "IsDeleted",
                value: false);
        }
    }
}
