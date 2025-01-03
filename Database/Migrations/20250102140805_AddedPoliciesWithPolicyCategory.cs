using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Deerlicious.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedPoliciesWithPolicyCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("484b71ff-af37-4903-a1f0-128b09cee719"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("091809b0-1494-4f26-815c-2cd3e5bd74bb"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("095443ce-ff96-49f2-89c5-3e0c1d1f8343"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("44e397c6-5c1a-4d01-83e1-38a929ea37c4"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("4b2fafd2-01ab-4624-b065-aa830014e51c"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("5098d94b-587e-4b2f-94d6-5b6ae75e502b"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("84a7c3dc-7850-436f-85ae-78e164d6fbec"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("84ae252a-e3e2-47b8-8e0f-c82c0b03efff"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("8f2f1fce-fa11-481f-a53b-293d3213ac75"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("97565198-0010-4eb8-80d2-24cc5701e175"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("975eed73-1e07-4361-87aa-1fc169e4cbcb"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("9f491c94-02e9-498a-84f9-d8fd9e57d1a4"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("ac87e392-d90f-41c5-afa8-7edbd69a2526"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("cc635c8e-c4de-4f1d-9b42-6d4aa63de053"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("d7ae701e-2e6d-4d13-a16d-090aada1df8e"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("f21d67a2-df14-42e4-8c26-5bab4f2bb4d4"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("fd45c66c-0717-491a-948a-6dd3eb8bf80f"));

            migrationBuilder.AddColumn<string>(
                name: "PolicyCategory",
                table: "Policies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("e91f3e70-48e4-4407-ac31-50a963ef00c1"));

            migrationBuilder.DropColumn(
                name: "PolicyCategory",
                table: "Policies");

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("484b71ff-af37-4903-a1f0-128b09cee719"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(5960), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(5970), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("091809b0-1494-4f26-815c-2cd3e5bd74bb"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6100), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanCreateUser", false, "CanCreateUser", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6100), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("095443ce-ff96-49f2-89c5-3e0c1d1f8343"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6170), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanDeleteAdministrator", false, "CanDeleteAdministrator", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6170), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("44e397c6-5c1a-4d01-83e1-38a929ea37c4"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6150), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanGetAdministrators", false, "CanGetAdministrators", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6150), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("4b2fafd2-01ab-4624-b065-aa830014e51c"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6170), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanGetContributors", false, "CanGetContributors", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6180), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("5098d94b-587e-4b2f-94d6-5b6ae75e502b"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6100), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanUpdateUser", false, "CanUpdateUser", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6100), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("84a7c3dc-7850-436f-85ae-78e164d6fbec"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6110), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanGetRoles", false, "CanGetRoles", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("84ae252a-e3e2-47b8-8e0f-c82c0b03efff"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6090), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanGetUsers", false, "CanGetUsers", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6090), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("8f2f1fce-fa11-481f-a53b-293d3213ac75"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6110), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanDeleteUser", false, "CanDeleteUser", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6110), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("97565198-0010-4eb8-80d2-24cc5701e175"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6160), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanUpdateAdministrator", false, "CanUpdateAdministrator", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6170), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("975eed73-1e07-4361-87aa-1fc169e4cbcb"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanCreateRole", false, "CanCreateRole", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("9f491c94-02e9-498a-84f9-d8fd9e57d1a4"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanUpdateContributor", false, "CanUpdateContributor", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("ac87e392-d90f-41c5-afa8-7edbd69a2526"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6130), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanUpdateRole", false, "CanUpdateRole", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6130), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("cc635c8e-c4de-4f1d-9b42-6d4aa63de053"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6150), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanDeleteRole", false, "CanDeleteRole", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6150), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("d7ae701e-2e6d-4d13-a16d-090aada1df8e"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanDeleteContributor", false, "CanDeleteContributor", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("f21d67a2-df14-42e4-8c26-5bab4f2bb4d4"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6160), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanCreateAdministrator", false, "CanCreateAdministrator", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6160), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("fd45c66c-0717-491a-948a-6dd3eb8bf80f"), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6180), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "CanCreateContributor", false, "CanCreateContributor", new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(6180), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(5910), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(5910), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(5530), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 2, 14, 35, 25, 498, DateTimeKind.Unspecified).AddTicks(5550), new TimeSpan(0, 1, 0, 0, 0)) });
        }
    }
}
