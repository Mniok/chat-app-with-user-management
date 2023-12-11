using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace musicCatalogDotNetAPI.Migrations
{
    public partial class TryRemoveTestUsersFromInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OriginalUserName", "Password", "UserName", "UserRole" },
                values: new object[] { new DateTime(2023, 12, 11, 9, 20, 3, 79, DateTimeKind.Local).AddTicks(522), "Admin", "admin123", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OriginalUserName", "Password", "UserName", "UserRole" },
                values: new object[] { new DateTime(2023, 12, 11, 0, 10, 39, 181, DateTimeKind.Local).AddTicks(5781), "testuser1", "testpass1", "testuser1", "BasicUser" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "BannedUntil", "CreatedAt", "MutedUntil", "OriginalUserName", "Password", "UserName", "UserRole" },
                values: new object[] { 2, null, new DateTime(2023, 12, 11, 0, 10, 39, 181, DateTimeKind.Local).AddTicks(5824), null, "testuser2", "testpass2", "testuser2", "BasicUser" });
        }
    }
}
