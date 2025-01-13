﻿// <auto-generated />
using System;
using Deerlicious.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Deerlicious.API.Database.Migrations
{
    [DbContext(typeof(DeerliciousContext))]
    partial class DeerliciousContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Administrator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Administrators");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8e2385a9-2ebf-4937-bf29-7ff6bcb997ea"),
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 13, 22, 40, 54, 252, DateTimeKind.Unspecified).AddTicks(4850), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            FirstName = "Super",
                            IsDeleted = false,
                            LastName = "Admin",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 13, 22, 40, 54, 252, DateTimeKind.Unspecified).AddTicks(4850), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            UserId = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        });
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Contributor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9b1e9a7-8bb0-4c29-86db-cbb4389e6393"),
                            Category = "Contributors",
                            Description = "Allows viewing contributors.",
                            Name = "CanGetContributors"
                        },
                        new
                        {
                            Id = new Guid("4b60b7a5-53c3-4b43-9793-b0354a29dca1"),
                            Category = "Contributors",
                            Description = "Allows creating new contributors.",
                            Name = "CanCreateContributor"
                        },
                        new
                        {
                            Id = new Guid("2f54d3f8-4f36-45f9-914d-12231b9c7a77"),
                            Category = "Contributors",
                            Description = "Allows updating existing contributors.",
                            Name = "CanUpdateContributor"
                        },
                        new
                        {
                            Id = new Guid("1b5a4f8f-4478-4e66-b636-4b7f5c3cdb28"),
                            Category = "Contributors",
                            Description = "Allows deleting contributors.",
                            Name = "CanDeleteContributor"
                        },
                        new
                        {
                            Id = new Guid("6bfa4f27-39cd-4a23-9a90-503b7562de09"),
                            Category = "Recipes",
                            Description = "Allows viewing recipes.",
                            Name = "CanGetRecipes"
                        },
                        new
                        {
                            Id = new Guid("74253b8e-6b5d-48f4-becb-02cc909de4bc"),
                            Category = "Recipes",
                            Description = "Allows creating recipes.",
                            Name = "CanCreateRecipe"
                        },
                        new
                        {
                            Id = new Guid("d07047e2-9c97-4f86-bb69-46699f9935b1"),
                            Category = "Recipes",
                            Description = "Allows updating recipes.",
                            Name = "CanUpdateRecipe"
                        },
                        new
                        {
                            Id = new Guid("b23e50c8-9e16-44b3-b7d4-b4e470306f87"),
                            Category = "Recipes",
                            Description = "Allows deleting recipes.",
                            Name = "CanDeleteRecipe"
                        },
                        new
                        {
                            Id = new Guid("d6fbb48f-5b7b-480c-8a12-117a8b5a68fd"),
                            Category = "Categories",
                            Description = "Allows viewing recipe categories.",
                            Name = "CanGetCategories"
                        },
                        new
                        {
                            Id = new Guid("2875f239-3d11-452e-acdd-b8bff6a50970"),
                            Category = "Categories",
                            Description = "Allows creating recipe categories.",
                            Name = "CanCreateCategory"
                        },
                        new
                        {
                            Id = new Guid("e8f80d47-e956-4e05-a91b-d51315e629fd"),
                            Category = "Categories",
                            Description = "Allows updating recipe category.",
                            Name = "CanUpdateCategory"
                        },
                        new
                        {
                            Id = new Guid("c02b2833-ded9-4e6b-af6a-74a06cb2ffe0"),
                            Category = "Categories",
                            Description = "Allows deleting recipe category.",
                            Name = "CanDeleteCategory"
                        });
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(30000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.RecipeCategory", b =>
                {
                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecipeId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("RecipeCategories");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f"),
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 13, 22, 40, 54, 252, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Role with all access.",
                            IsDeleted = false,
                            Name = "SuperAdmin",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 13, 22, 40, 54, 252, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        });
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.RolePermission", b =>
                {
                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PermissionId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 13, 22, 40, 54, 252, DateTimeKind.Unspecified).AddTicks(4240), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Email = "superadmin@mail.com",
                            EmailConfirmed = true,
                            IsDeleted = false,
                            Password = "685D8127992F8280BB94EC3CF3F2B4DA35904A8AE09AC07AF245D1888A620FAF97DE8084F4141D5F2107BEB09FC7F57073EAE8746A000A0DFFD507C79ED055A3",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 13, 22, 40, 54, 252, DateTimeKind.Unspecified).AddTicks(4290), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            UserName = "superadmin"
                        });
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            RoleId = new Guid("69a4116d-b1bd-4f0b-b6a7-a13bb5eb639f")
                        });
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Administrator", b =>
                {
                    b.HasOne("Deerlicious.API.Database.Entities.User", "User")
                        .WithOne("Administrator")
                        .HasForeignKey("Deerlicious.API.Database.Entities.Administrator", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Contributor", b =>
                {
                    b.HasOne("Deerlicious.API.Database.Entities.User", "User")
                        .WithOne("Contributor")
                        .HasForeignKey("Deerlicious.API.Database.Entities.Contributor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.RecipeCategory", b =>
                {
                    b.HasOne("Deerlicious.API.Database.Entities.Category", "Category")
                        .WithMany("Recipes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deerlicious.API.Database.Entities.Recipe", "Recipe")
                        .WithMany("Categories")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.RolePermission", b =>
                {
                    b.HasOne("Deerlicious.API.Database.Entities.Permission", "Permission")
                        .WithMany("Roles")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deerlicious.API.Database.Entities.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.UserRole", b =>
                {
                    b.HasOne("Deerlicious.API.Database.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deerlicious.API.Database.Entities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Category", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Permission", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Recipe", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Role", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.User", b =>
                {
                    b.Navigation("Administrator")
                        .IsRequired();

                    b.Navigation("Contributor")
                        .IsRequired();

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
