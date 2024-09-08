using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaRecommendationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedDiscardedMenuItemFeedbackFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscardedMenuItemFeedback_DiscardedMenuItems",
                table: "DiscardedMenyItemFeedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscardedMenyItemFeedback",
                table: "DiscardedMenyItemFeedback");

            migrationBuilder.RenameTable(
                name: "DiscardedMenyItemFeedback",
                newName: "DiscardedMenuItemFeedback");

            migrationBuilder.RenameIndex(
                name: "IX_DiscardedMenyItemFeedback_UserId",
                table: "DiscardedMenuItemFeedback",
                newName: "IX_DiscardedMenuItemFeedback_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscardedMenyItemFeedback_DiscardedMenuItemId",
                table: "DiscardedMenuItemFeedback",
                newName: "IX_DiscardedMenuItemFeedback_DiscardedMenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscardedMenuItemFeedback",
                table: "DiscardedMenuItemFeedback",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 30, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 7, 2, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2140));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 7, 4, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 7, 15, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 7, 1, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2145));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2146));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 7, 4, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2148));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 7, 2, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2024, 7, 1, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2024, 7, 2, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2024, 7, 4, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2024, 7, 15, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2024, 6, 30, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2024, 7, 2, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2024, 7, 4, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2024, 7, 4, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 21,
                column: "Date",
                value: new DateTime(2024, 7, 1, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 22,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 23,
                column: "Date",
                value: new DateTime(2024, 7, 4, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 24,
                column: "Date",
                value: new DateTime(2024, 7, 2, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "ID",
                keyValue: 25,
                column: "Date",
                value: new DateTime(2024, 7, 3, 22, 29, 27, 570, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.AddForeignKey(
                name: "FK_DiscardedMenuItemFeedback_DiscardedMenuItem",
                table: "DiscardedMenuItemFeedback",
                column: "DiscardedMenuItemId",
                principalTable: "DiscardedMenuItem",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscardedMenuItemFeedback_DiscardedMenuItem",
                table: "DiscardedMenuItemFeedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscardedMenuItemFeedback",
                table: "DiscardedMenuItemFeedback");

            migrationBuilder.RenameTable(
                name: "DiscardedMenuItemFeedback",
                newName: "DiscardedMenyItemFeedback");

            migrationBuilder.RenameIndex(
                name: "IX_DiscardedMenuItemFeedback_UserId",
                table: "DiscardedMenyItemFeedback",
                newName: "IX_DiscardedMenyItemFeedback_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscardedMenuItemFeedback_DiscardedMenuItemId",
                table: "DiscardedMenyItemFeedback",
                newName: "IX_DiscardedMenyItemFeedback_DiscardedMenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscardedMenyItemFeedback",
                table: "DiscardedMenyItemFeedback",
                column: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DiscardedMenuItemFeedback_DiscardedMenuItems",
                table: "DiscardedMenyItemFeedback",
                column: "DiscardedMenuItemId",
                principalTable: "DiscardedMenuItem",
                principalColumn: "ID");
        }
    }
}
