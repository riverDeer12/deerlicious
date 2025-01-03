using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Deerlicious.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedPoliciesWithPolicyCategory_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("e91f3e70-48e4-4407-ac31-50a963ef00c1"));

            migrationBuilder.RenameColumn(
                name: "PolicyCategory",
                table: "Policies",
                newName: "Category");

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("08a444db-67ae-40f5-ac86-53ba7eaa5dd5"), new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4510), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1080b1d6-514c-484a-b5d2-992f7927e542"), "Users", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4600), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows viewing users.", false, "CanGetUsers", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4600), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("1dfba308-3a25-4367-b259-eecb46fd01a6"), "Administrators", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4650), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows updating existing administrators.", false, "CanUpdateAdministrator", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4650), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("1fe913a5-21dd-4afb-b5e4-5f44ca74fccc"), "Roles", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows updating existing roles.", false, "CanUpdateRole", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("265bd962-60ae-41a8-8de2-40854eb85ea3"), "Administrators", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4650), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows creating new administrators.", false, "CanCreateAdministrator", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4650), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("28851557-7170-4365-9a4c-e1c3a1564431"), "Contributors", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows updating existing contributors.", false, "CanUpdateContributor", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("2a7135b9-03da-4344-a640-6589ce09e56f"), "Contributors", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4680), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows deleting contributors.", false, "CanDeleteContributor", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4680), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("5a7c4365-b6dd-498f-b267-f9c24d2225ee"), "Roles", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4620), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows viewing roles.", false, "CanGetRoles", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4620), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("67b8592a-d52f-4fb1-8106-8f911dc1ceeb"), "Users", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4620), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows deleting users.", false, "CanDeleteUser", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4620), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("9e93b29c-df7f-4971-9594-7ce09e60205a"), "Roles", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows creating new roles.", false, "CanCreateRole", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("ace73f6c-77c1-49ec-94aa-efc206d32e12"), "Users", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4600), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows creating new users.", false, "CanCreateUser", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("c4bb884b-a59d-4314-a4fa-68a599d46af0"), "Contributors", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows creating new contributors.", false, "CanCreateContributor", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("c84042f1-54cb-449b-a8fa-6ad47f903f9f"), "Administrators", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows viewing administrators.", false, "CanGetAdministrators", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("d74774f0-1531-4bd0-8ebf-0f2909f9c95a"), "Administrators", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4660), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows deleting administrators.", false, "CanDeleteAdministrator", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4660), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("daee3ebd-1bce-4fb9-a746-5a1fa09aafb9"), "Roles", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows deleting roles.", false, "CanDeleteRole", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("fa655e50-080b-4dbe-b186-8ac378f3b543"), "Users", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows updating existing users.", false, "CanUpdateUser", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("fe9b09a9-b58f-4783-8c81-1e34faa458af"), "Contributors", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4660), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows viewing contributors.", false, "CanGetContributors", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4660), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4450), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4450), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4050), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4080), new TimeSpan(0, 1, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("08a444db-67ae-40f5-ac86-53ba7eaa5dd5"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("1080b1d6-514c-484a-b5d2-992f7927e542"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("1dfba308-3a25-4367-b259-eecb46fd01a6"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("1fe913a5-21dd-4afb-b5e4-5f44ca74fccc"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("265bd962-60ae-41a8-8de2-40854eb85ea3"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("28851557-7170-4365-9a4c-e1c3a1564431"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("2a7135b9-03da-4344-a640-6589ce09e56f"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("5a7c4365-b6dd-498f-b267-f9c24d2225ee"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("67b8592a-d52f-4fb1-8106-8f911dc1ceeb"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("9e93b29c-df7f-4971-9594-7ce09e60205a"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("ace73f6c-77c1-49ec-94aa-efc206d32e12"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("c4bb884b-a59d-4314-a4fa-68a599d46af0"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("c84042f1-54cb-449b-a8fa-6ad47f903f9f"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("d74774f0-1531-4bd0-8ebf-0f2909f9c95a"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("daee3ebd-1bce-4fb9-a746-5a1fa09aafb9"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("fa655e50-080b-4dbe-b186-8ac378f3b543"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("fe9b09a9-b58f-4783-8c81-1e34faa458af"));

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Policies",
                newName: "PolicyCategory");

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("e91f3e70-48e4-4407-ac31-50a963ef00c1"), new DateTimeOffset(new DateTime(2025, 1, 2, 15, 8, 4, 848, DateTimeKind.Unspecified).AddTicks(3710), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 1, 2, 15, 8, 4, 848, DateTimeKind.Unspecified).AddTicks(3710), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 2, 15, 8, 4, 848, DateTimeKind.Unspecified).AddTicks(3660), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 2, 15, 8, 4, 848, DateTimeKind.Unspecified).AddTicks(3670), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 2, 15, 8, 4, 848, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 2, 15, 8, 4, 848, DateTimeKind.Unspecified).AddTicks(3310), new TimeSpan(0, 1, 0, 0, 0)) });
        }
    }
}
