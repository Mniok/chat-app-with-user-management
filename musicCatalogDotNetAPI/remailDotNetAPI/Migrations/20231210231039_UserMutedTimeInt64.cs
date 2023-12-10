using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace musicCatalogDotNetAPI.Migrations
{
    public partial class UserMutedTimeInt64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 11, 0, 10, 39, 181, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 11, 0, 10, 39, 181, DateTimeKind.Local).AddTicks(5824));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 10, 1, 49, 30, 716, DateTimeKind.Local).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 10, 1, 49, 30, 716, DateTimeKind.Local).AddTicks(744));
        }
    }
}
