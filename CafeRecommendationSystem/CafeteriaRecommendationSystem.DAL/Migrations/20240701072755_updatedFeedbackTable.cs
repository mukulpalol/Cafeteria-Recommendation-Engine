using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaRecommendationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedFeedbackTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SentimentScore",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 16, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(258), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 18, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(294), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(298), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(300), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 7, 1, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(325), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(349), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(352), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(355), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 18, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(357), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(360), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(362), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 18, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(365), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(368), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(371), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 7, 1, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(377), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 16, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(379), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 18, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(382), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(384), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(387), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(390), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(392), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(395), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 20, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(398), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 18, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(401), 0 });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "Date", "SentimentScore" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 57, 54, 767, DateTimeKind.Local).AddTicks(403), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SentimentScore",
                table: "Feedback");

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
    }
}
