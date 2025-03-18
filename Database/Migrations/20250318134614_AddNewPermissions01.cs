using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Deerlicious.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPermissions01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("8b21a4fb-e353-4b25-8fab-0bdcbb9c6d20"));

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("e270764f-a9c1-4351-ac54-e8f95bb9bd6c"), new DateTimeOffset(new DateTime(2025, 3, 18, 14, 46, 14, 160, DateTimeKind.Unspecified).AddTicks(1770), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 3, 18, 14, 46, 14, 160, DateTimeKind.Unspecified).AddTicks(1770), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Category", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2fe1ad9e-4229-411f-8095-e8f289777455"), "Users", "Allows updating user.", "CanUpdateUser" },
                    { new Guid("a4e62d67-676d-4f53-9ace-b4c600ea9718"), "Users", "Allows creating user.", "CanCreateUser" },
                    { new Guid("f250b493-7826-4a43-968f-d1392d925b96"), "Users", "Allows deleting user.", "CanDeleteUser" },
                    { new Guid("fa6a2e89-cf1e-4e4c-bd3a-c95365c52f81"), "Users", "Allows viewing users.", "CanGetUsers" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 18, 14, 46, 14, 160, DateTimeKind.Unspecified).AddTicks(1720), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 18, 14, 46, 14, 160, DateTimeKind.Unspecified).AddTicks(1720), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 18, 14, 46, 14, 160, DateTimeKind.Unspecified).AddTicks(1230), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 18, 14, 46, 14, 160, DateTimeKind.Unspecified).AddTicks(1280), new TimeSpan(0, 1, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("e270764f-a9c1-4351-ac54-e8f95bb9bd6c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2fe1ad9e-4229-411f-8095-e8f289777455"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a4e62d67-676d-4f53-9ace-b4c600ea9718"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f250b493-7826-4a43-968f-d1392d925b96"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("fa6a2e89-cf1e-4e4c-bd3a-c95365c52f81"));

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("8b21a4fb-e353-4b25-8fab-0bdcbb9c6d20"), new DateTimeOffset(new DateTime(2025, 3, 18, 14, 28, 48, 251, DateTimeKind.Unspecified).AddTicks(8830), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 3, 18, 14, 28, 48, 251, DateTimeKind.Unspecified).AddTicks(8840), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 18, 14, 28, 48, 251, DateTimeKind.Unspecified).AddTicks(8770), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 18, 14, 28, 48, 251, DateTimeKind.Unspecified).AddTicks(8770), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 3, 18, 14, 28, 48, 251, DateTimeKind.Unspecified).AddTicks(8320), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 3, 18, 14, 28, 48, 251, DateTimeKind.Unspecified).AddTicks(8370), new TimeSpan(0, 1, 0, 0, 0)) });
        }
    }
}
