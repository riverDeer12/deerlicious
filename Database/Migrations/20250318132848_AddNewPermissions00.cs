using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Deerlicious.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPermissions00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("f36600a4-80b3-459e-967c-19da01f16df6"));

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("8b21a4fb-e353-4b25-8fab-0bdcbb9c6d20"), new DateTimeOffset(new DateTime(2025, 3, 18, 14, 28, 48, 251, DateTimeKind.Unspecified).AddTicks(8830), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 3, 18, 14, 28, 48, 251, DateTimeKind.Unspecified).AddTicks(8840), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Category", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2070c041-997a-43d6-8a01-ba04c8f1b1ed"), "Administrators", "Allows deleting administrator.", "CanDeleteAdministrator" },
                    { new Guid("3808be7c-782b-4fcf-8d2b-b9cd3a2bb8ee"), "Administrators", "Allows viewing administrators.", "CanGetAdministrators" },
                    { new Guid("5bdaa142-aae1-4225-8e8e-2539e74bd616"), "Administrators", "Allows updating administrator.", "CanUpdateAdministrator" },
                    { new Guid("d7775310-c4ff-4fd4-bf3b-719d85b60b4c"), "Administrators", "Allows creating administrator.", "CanCreateAdministrator" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("8b21a4fb-e353-4b25-8fab-0bdcbb9c6d20"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2070c041-997a-43d6-8a01-ba04c8f1b1ed"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("3808be7c-782b-4fcf-8d2b-b9cd3a2bb8ee"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("5bdaa142-aae1-4225-8e8e-2539e74bd616"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("d7775310-c4ff-4fd4-bf3b-719d85b60b4c"));

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("f36600a4-80b3-459e-967c-19da01f16df6"), new DateTimeOffset(new DateTime(2025, 1, 21, 12, 59, 1, 581, DateTimeKind.Unspecified).AddTicks(3490), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 1, 21, 12, 59, 1, 581, DateTimeKind.Unspecified).AddTicks(3490), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 21, 12, 59, 1, 581, DateTimeKind.Unspecified).AddTicks(3430), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 21, 12, 59, 1, 581, DateTimeKind.Unspecified).AddTicks(3440), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 21, 12, 59, 1, 581, DateTimeKind.Unspecified).AddTicks(3000), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 21, 12, 59, 1, 581, DateTimeKind.Unspecified).AddTicks(3040), new TimeSpan(0, 1, 0, 0, 0)) });
        }
    }
}
