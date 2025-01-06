using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Deerlicious.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPolicies_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Policies");

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("b3ab8ecd-4348-4fce-a73f-a6bbdc65edad"), new DateTimeOffset(new DateTime(2025, 1, 6, 22, 28, 42, 939, DateTimeKind.Unspecified).AddTicks(7070), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 28, 42, 939, DateTimeKind.Unspecified).AddTicks(7080), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "Category", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1b5a4f8f-4478-4e66-b636-4b7f5c3cdb28"), "Contributors", "Allows deleting contributors.", "CanDeleteContributor" },
                    { new Guid("2f54d3f8-4f36-45f9-914d-12231b9c7a77"), "Contributors", "Allows updating existing contributors.", "CanUpdateContributor" },
                    { new Guid("4b60b7a5-53c3-4b43-9793-b0354a29dca1"), "Contributors", "Allows creating new contributors.", "CanCreateContributor" },
                    { new Guid("6bfa4f27-39cd-4a23-9a90-503b7562de09"), "Recipes", "Allows viewing recipes.", "CanGetRecipes" },
                    { new Guid("74253b8e-6b5d-48f4-becb-02cc909de4bc"), "Recipes", "Allows creating recipes.", "CanCreateRecipe" },
                    { new Guid("b23e50c8-9e16-44b3-b7d4-b4e470306f87"), "Recipes", "Allows deleting recipes.", "CanDeleteRecipe" },
                    { new Guid("c9b1e9a7-8bb0-4c29-86db-cbb4389e6393"), "Contributors", "Allows viewing contributors.", "CanGetContributors" },
                    { new Guid("d07047e2-9c97-4f86-bb69-46699f9935b1"), "Recipes", "Allows updating recipes.", "CanUpdateRecipe" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 6, 22, 28, 42, 939, DateTimeKind.Unspecified).AddTicks(7010), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 6, 22, 28, 42, 939, DateTimeKind.Unspecified).AddTicks(7020), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 6, 22, 28, 42, 939, DateTimeKind.Unspecified).AddTicks(6540), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 6, 22, 28, 42, 939, DateTimeKind.Unspecified).AddTicks(6600), new TimeSpan(0, 1, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("b3ab8ecd-4348-4fce-a73f-a6bbdc65edad"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("1b5a4f8f-4478-4e66-b636-4b7f5c3cdb28"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("2f54d3f8-4f36-45f9-914d-12231b9c7a77"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("4b60b7a5-53c3-4b43-9793-b0354a29dca1"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("6bfa4f27-39cd-4a23-9a90-503b7562de09"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("74253b8e-6b5d-48f4-becb-02cc909de4bc"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("b23e50c8-9e16-44b3-b7d4-b4e470306f87"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("c9b1e9a7-8bb0-4c29-86db-cbb4389e6393"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("d07047e2-9c97-4f86-bb69-46699f9935b1"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Policies",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Policies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "Policies",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Policies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Policies",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Policies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
