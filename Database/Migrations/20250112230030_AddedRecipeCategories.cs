using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Deerlicious.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedRecipeCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("b3ab8ecd-4348-4fce-a73f-a6bbdc65edad"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 30000, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => new { x.RecipeId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("af4c6e39-f988-4944-af82-0b0fa4829afa"), new DateTimeOffset(new DateTime(2025, 1, 13, 0, 0, 30, 732, DateTimeKind.Unspecified).AddTicks(9040), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 1, 13, 0, 0, 30, 732, DateTimeKind.Unspecified).AddTicks(9040), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "Category", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2875f239-3d11-452e-acdd-b8bff6a50970"), "Categories", "Allows creating recipe categories.", "CanCreateCategory" },
                    { new Guid("c02b2833-ded9-4e6b-af6a-74a06cb2ffe0"), "Categories", "Allows deleting recipe category.", "CanDeleteCategory" },
                    { new Guid("d6fbb48f-5b7b-480c-8a12-117a8b5a68fd"), "Categories", "Allows viewing recipe categories.", "CanGetCategories" },
                    { new Guid("e8f80d47-e956-4e05-a91b-d51315e629fd"), "Categories", "Allows updating recipe category.", "CanUpdateCategory" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 13, 0, 0, 30, 732, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 13, 0, 0, 30, 732, DateTimeKind.Unspecified).AddTicks(8990), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 13, 0, 0, 30, 732, DateTimeKind.Unspecified).AddTicks(8550), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 13, 0, 0, 30, 732, DateTimeKind.Unspecified).AddTicks(8610), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategories_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("af4c6e39-f988-4944-af82-0b0fa4829afa"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("2875f239-3d11-452e-acdd-b8bff6a50970"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("c02b2833-ded9-4e6b-af6a-74a06cb2ffe0"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("d6fbb48f-5b7b-480c-8a12-117a8b5a68fd"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: new Guid("e8f80d47-e956-4e05-a91b-d51315e629fd"));

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("b3ab8ecd-4348-4fce-a73f-a6bbdc65edad"), new DateTimeOffset(new DateTime(2025, 1, 6, 22, 28, 42, 939, DateTimeKind.Unspecified).AddTicks(7070), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 1, 6, 22, 28, 42, 939, DateTimeKind.Unspecified).AddTicks(7080), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

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
    }
}
