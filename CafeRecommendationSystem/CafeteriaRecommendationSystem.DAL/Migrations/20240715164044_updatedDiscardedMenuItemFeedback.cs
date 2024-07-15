using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaRecommendationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedDiscardedMenuItemFeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscardedMenuItemFeedback_DiscardedMenuItems",
                table: "DiscardedMenyItemFeedback");

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 30, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 7, 2, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7288));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7293));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 7, 4, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 7, 15, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 7, 1, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 7, 4, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 7, 2, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 7, 1, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2024, 7, 2, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2024, 7, 4, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2024, 7, 15, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2024, 6, 30, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7351));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2024, 7, 2, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7353));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2024, 7, 4, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 7, 4, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2024, 7, 1, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2024, 7, 4, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7361));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2024, 7, 2, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 10, 43, 919, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.CreateIndex(
                name: "IX_DiscardedMenyItemFeedback_DiscardedMenuItemId",
                table: "DiscardedMenyItemFeedback",
                column: "DiscardedMenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscardedMenuItemFeedback_DiscardedMenuItems",
                table: "DiscardedMenyItemFeedback",
                column: "DiscardedMenuItemId",
                principalTable: "DiscardedMenuItem",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscardedMenuItemFeedback_DiscardedMenuItems",
                table: "DiscardedMenyItemFeedback");

            migrationBuilder.DropIndex(
                name: "IX_DiscardedMenyItemFeedback_DiscardedMenuItemId",
                table: "DiscardedMenyItemFeedback");

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 18, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 20, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 6, 22, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 7, 3, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 6, 19, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 6, 22, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 6, 20, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1011));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 6, 19, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1013));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2024, 6, 20, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2024, 6, 22, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1015));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1016));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2024, 7, 3, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2024, 6, 18, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2024, 6, 20, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2024, 6, 22, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 6, 22, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1021));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2024, 6, 19, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2024, 6, 22, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1025));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2024, 6, 20, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2024, 6, 21, 17, 42, 43, 731, DateTimeKind.Local).AddTicks(1027));

            migrationBuilder.AddForeignKey(
                name: "FK_DiscardedMenuItemFeedback_DiscardedMenuItems",
                table: "DiscardedMenyItemFeedback",
                column: "UserId",
                principalTable: "DiscardedMenuItem",
                principalColumn: "ID");
        }
    }
}
