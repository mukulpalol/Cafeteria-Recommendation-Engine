using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaRecommendationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedMenuItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecommendationScore",
                table: "Recommendations");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinalised",
                table: "Recommendations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GeneralSentiment",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SentimentScore",
                table: "MenuItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "GeneralSentiment", "SentimentScore" },
                values: new object[] { "good", 0.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "GeneralSentiment", "SentimentScore" },
                values: new object[] { "good", 0.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "GeneralSentiment", "SentimentScore" },
                values: new object[] { "good", 0.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "GeneralSentiment", "SentimentScore" },
                values: new object[] { "good", 0.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "GeneralSentiment", "SentimentScore" },
                values: new object[] { "good", 0.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "GeneralSentiment", "SentimentScore" },
                values: new object[] { "good", 0.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "GeneralSentiment", "SentimentScore" },
                values: new object[] { "good", 0.49m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "GeneralSentiment", "SentimentScore" },
                values: new object[] { "good", 0.49m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinalised",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "GeneralSentiment",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "SentimentScore",
                table: "MenuItems");

            migrationBuilder.AddColumn<decimal>(
                name: "RecommendationScore",
                table: "Recommendations",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 15, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(5986));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 17, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 6, 19, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 6, 20, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 6, 16, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 6, 19, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 6, 17, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 6, 16, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2024, 6, 17, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2024, 6, 19, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2024, 6, 20, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2024, 6, 15, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2024, 6, 17, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2024, 6, 19, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 6, 19, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2024, 6, 16, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2024, 6, 19, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2024, 6, 17, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6023));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2024, 6, 18, 23, 48, 1, 632, DateTimeKind.Local).AddTicks(6024));
        }
    }
}
