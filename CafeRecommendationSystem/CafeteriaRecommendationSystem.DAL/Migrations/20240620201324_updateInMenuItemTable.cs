using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaRecommendationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateInMenuItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsFinalised",
                table: "Recommendations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<decimal>(
                name: "SentimentScore",
                table: "MenuItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 16, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9583));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 18, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9615));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 6, 20, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9618));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 6, 21, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9621));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 6, 17, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9627));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 6, 20, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9630));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 6, 18, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9636));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 6, 17, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2024, 6, 18, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2024, 6, 20, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9658));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2024, 6, 21, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2024, 6, 16, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2024, 6, 18, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9669));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2024, 6, 20, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 6, 20, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2024, 6, 17, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9684));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2024, 6, 20, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9687));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2024, 6, 18, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 43, 24, 198, DateTimeKind.Local).AddTicks(9694));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsFinalised",
                table: "Recommendations",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<decimal>(
                name: "SentimentScore",
                table: "MenuItems",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 16, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 18, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(460));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 6, 20, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 6, 21, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(464));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 6, 17, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(465));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(467));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 6, 20, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(468));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 6, 18, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(470));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 6, 17, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2024, 6, 18, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(474));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2024, 6, 20, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(477));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2024, 6, 21, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(478));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2024, 6, 16, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(480));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2024, 6, 18, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(481));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2024, 6, 20, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 6, 20, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2024, 6, 17, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(489));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2024, 6, 20, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2024, 6, 18, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(493));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2024, 6, 19, 1, 36, 36, 740, DateTimeKind.Local).AddTicks(495));
        }
    }
}
