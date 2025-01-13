using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deerlicious.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class PoliciesToPermissions_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePolicies_Permissions_PermissionId",
                table: "RolePolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePolicies_Roles_RoleId",
                table: "RolePolicies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePolicies",
                table: "RolePolicies");

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("4d5c05ff-d869-4594-a50a-da9c54c355ea"));

            migrationBuilder.RenameTable(
                name: "RolePolicies",
                newName: "RolePermissions");

            migrationBuilder.RenameIndex(
                name: "IX_RolePolicies_RoleId",
                table: "RolePermissions",
                newName: "IX_RolePermissions_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("8e2385a9-2ebf-4937-bf29-7ff6bcb997ea"), new DateTimeOffset(new DateTime(2025, 1, 13, 22, 40, 54, 252, DateTimeKind.Unspecified).AddTicks(4850), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 1, 13, 22, 40, 54, 252, DateTimeKind.Unspecified).AddTicks(4850), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 13, 22, 40, 54, 252, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 13, 22, 40, 54, 252, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 13, 22, 40, 54, 252, DateTimeKind.Unspecified).AddTicks(4240), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 13, 22, 40, 54, 252, DateTimeKind.Unspecified).AddTicks(4290), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions");

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("8e2385a9-2ebf-4937-bf29-7ff6bcb997ea"));

            migrationBuilder.RenameTable(
                name: "RolePermissions",
                newName: "RolePolicies");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePolicies",
                newName: "IX_RolePolicies_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePolicies",
                table: "RolePolicies",
                columns: new[] { "PermissionId", "RoleId" });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("4d5c05ff-d869-4594-a50a-da9c54c355ea"), new DateTimeOffset(new DateTime(2025, 1, 13, 22, 37, 6, 412, DateTimeKind.Unspecified).AddTicks(9080), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), null, "Super", false, "Admin", new DateTimeOffset(new DateTime(2025, 1, 13, 22, 37, 6, 412, DateTimeKind.Unspecified).AddTicks(9080), new TimeSpan(0, 1, 0, 0, 0)), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"), new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb") });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 13, 22, 37, 6, 412, DateTimeKind.Unspecified).AddTicks(9030), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 13, 22, 37, 6, 412, DateTimeKind.Unspecified).AddTicks(9030), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 1, 13, 22, 37, 6, 412, DateTimeKind.Unspecified).AddTicks(8550), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2025, 1, 13, 22, 37, 6, 412, DateTimeKind.Unspecified).AddTicks(8600), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_RolePolicies_Permissions_PermissionId",
                table: "RolePolicies",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePolicies_Roles_RoleId",
                table: "RolePolicies",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
