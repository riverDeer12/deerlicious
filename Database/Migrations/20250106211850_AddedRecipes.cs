using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Deerlicious.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("9e1e75eb-3c93-41ac-a731-d0234e8524f5"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("14586154-9c2f-42ca-8acb-622ebd7a1cf6"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("5176d0de-5459-4390-8371-64327ca0a936"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("a4596b83-351f-47d4-bd76-3ffc37d6437a"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("f7a17009-275d-49f1-93a5-7986831149fa"));

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 30000, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("ee81602f-4cc7-4aca-9785-aebf9a4137e0"), new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3120), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3120), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("1febe8cf-a4eb-48fa-a899-013198b3c503"), "Recipes", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows creating recipes.", false, "CanCreateRecipe", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("4fcac512-7476-4c6f-b40c-6daadd829b65"), "Contributors", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows deleting contributors.", false, "CanDeleteContributor", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("50d9aa48-e3a9-4da4-b583-54477d71936b"), "Contributors", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows updating existing contributors.", false, "CanUpdateContributor", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("5eac0113-a223-4246-a6be-efa25f4180ef"), "Contributors", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows creating new contributors.", false, "CanCreateContributor", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("67604b60-f3bd-4e24-8fa1-ce62191ad0a9"), "Recipes", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3280), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows deleting recipes.", false, "CanDeleteRecipe", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3280), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("780c2d2b-1c88-40ff-90cb-70883d989383"), "Recipes", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3270), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows updating recipes.", false, "CanUpdateRecipe", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3270), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("b6de032b-31c0-4c5d-b9cd-379bfceac29c"), "Recipes", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3270), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows creating recipes.", false, "CanCreateRecipe", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3270), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("fedc54d6-8d20-46f8-b88d-13c42e27e03c"), "Contributors", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3240), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows viewing contributors.", false, "CanGetContributors", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3240), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3050), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(3050), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(2490), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 6, 22, 18, 49, 858, DateTimeKind.Unspecified).AddTicks(2550), new TimeSpan(0, 1, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("ee81602f-4cc7-4aca-9785-aebf9a4137e0"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("1febe8cf-a4eb-48fa-a899-013198b3c503"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("4fcac512-7476-4c6f-b40c-6daadd829b65"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("50d9aa48-e3a9-4da4-b583-54477d71936b"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("5eac0113-a223-4246-a6be-efa25f4180ef"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("67604b60-f3bd-4e24-8fa1-ce62191ad0a9"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("780c2d2b-1c88-40ff-90cb-70883d989383"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("b6de032b-31c0-4c5d-b9cd-379bfceac29c"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("fedc54d6-8d20-46f8-b88d-13c42e27e03c"));

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("9e1e75eb-3c93-41ac-a731-d0234e8524f5"), new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(7020), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(7020), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("14586154-9c2f-42ca-8acb-622ebd7a1cf6"), "Contributors", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(7120), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows creating new contributors.", false, "CanCreateContributor", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(7120), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("5176d0de-5459-4390-8371-64327ca0a936"), "Contributors", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(7110), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows viewing contributors.", false, "CanGetContributors", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(7110), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("a4596b83-351f-47d4-bd76-3ffc37d6437a"), "Contributors", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(7130), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows deleting contributors.", false, "CanDeleteContributor", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(7130), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") },
                    { new Guid("f7a17009-275d-49f1-93a5-7986831149fa"), "Contributors", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(7130), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Allows updating existing contributors.", false, "CanUpdateContributor", new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(7130), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(6960), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(6960), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 2, 16, 43, 11, 396, DateTimeKind.Unspecified).AddTicks(6430), new TimeSpan(0, 1, 0, 0, 0)) });
        }
    }
}
