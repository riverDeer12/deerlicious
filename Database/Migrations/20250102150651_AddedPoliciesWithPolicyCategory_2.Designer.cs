﻿// <auto-generated />
using System;
using Deerlicious.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Deerlicious.API.Database.Migrations
{
    [DbContext(typeof(DeerliciousContext))]
    [Migration("20250102150651_AddedPoliciesWithPolicyCategory_2")]
    partial class AddedPoliciesWithPolicyCategory_2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("08a444db-67ae-40f5-ac86-53ba7eaa5dd5"),
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            FirstName = "Super",
                            IsDeleted = false,
                            LastName = "Admin",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4510), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            UserId = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        });
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

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Policy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("Policies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1080b1d6-514c-484a-b5d2-992f7927e542"),
                            Category = "Users",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4600), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows viewing users.",
                            IsDeleted = false,
                            Name = "CanGetUsers",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4600), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("ace73f6c-77c1-49ec-94aa-efc206d32e12"),
                            Category = "Users",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4600), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows creating new users.",
                            IsDeleted = false,
                            Name = "CanCreateUser",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("fa655e50-080b-4dbe-b186-8ac378f3b543"),
                            Category = "Users",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows updating existing users.",
                            IsDeleted = false,
                            Name = "CanUpdateUser",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4610), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("67b8592a-d52f-4fb1-8106-8f911dc1ceeb"),
                            Category = "Users",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4620), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows deleting users.",
                            IsDeleted = false,
                            Name = "CanDeleteUser",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4620), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("5a7c4365-b6dd-498f-b267-f9c24d2225ee"),
                            Category = "Roles",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4620), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows viewing roles.",
                            IsDeleted = false,
                            Name = "CanGetRoles",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4620), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("9e93b29c-df7f-4971-9594-7ce09e60205a"),
                            Category = "Roles",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows creating new roles.",
                            IsDeleted = false,
                            Name = "CanCreateRole",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("1fe913a5-21dd-4afb-b5e4-5f44ca74fccc"),
                            Category = "Roles",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows updating existing roles.",
                            IsDeleted = false,
                            Name = "CanUpdateRole",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("daee3ebd-1bce-4fb9-a746-5a1fa09aafb9"),
                            Category = "Roles",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows deleting roles.",
                            IsDeleted = false,
                            Name = "CanDeleteRole",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("c84042f1-54cb-449b-a8fa-6ad47f903f9f"),
                            Category = "Administrators",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows viewing administrators.",
                            IsDeleted = false,
                            Name = "CanGetAdministrators",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4640), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("265bd962-60ae-41a8-8de2-40854eb85ea3"),
                            Category = "Administrators",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4650), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows creating new administrators.",
                            IsDeleted = false,
                            Name = "CanCreateAdministrator",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4650), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("1dfba308-3a25-4367-b259-eecb46fd01a6"),
                            Category = "Administrators",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4650), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows updating existing administrators.",
                            IsDeleted = false,
                            Name = "CanUpdateAdministrator",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4650), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("d74774f0-1531-4bd0-8ebf-0f2909f9c95a"),
                            Category = "Administrators",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4660), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows deleting administrators.",
                            IsDeleted = false,
                            Name = "CanDeleteAdministrator",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4660), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("fe9b09a9-b58f-4783-8c81-1e34faa458af"),
                            Category = "Contributors",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4660), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows viewing contributors.",
                            IsDeleted = false,
                            Name = "CanGetContributors",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4660), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("c4bb884b-a59d-4314-a4fa-68a599d46af0"),
                            Category = "Contributors",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows creating new contributors.",
                            IsDeleted = false,
                            Name = "CanCreateContributor",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("28851557-7170-4365-9a4c-e1c3a1564431"),
                            Category = "Contributors",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows updating existing contributors.",
                            IsDeleted = false,
                            Name = "CanUpdateContributor",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4670), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        },
                        new
                        {
                            Id = new Guid("2a7135b9-03da-4344-a640-6589ce09e56f"),
                            Category = "Contributors",
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4680), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Allows deleting contributors.",
                            IsDeleted = false,
                            Name = "CanDeleteContributor",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4680), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        });
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
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4450), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Description = "Role with all access.",
                            IsDeleted = false,
                            Name = "SuperAdmin",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4450), new TimeSpan(0, 1, 0, 0, 0)),
                            UpdatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb")
                        });
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.RolePolicy", b =>
                {
                    b.Property<Guid>("PolicyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PolicyId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePolicies");
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
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4050), new TimeSpan(0, 1, 0, 0, 0)),
                            CreatedBy = new Guid("5604e898-cd94-476b-8b86-9aa3a87cc9bb"),
                            Email = "superadmin@mail.com",
                            EmailConfirmed = true,
                            IsDeleted = false,
                            Password = "685D8127992F8280BB94EC3CF3F2B4DA35904A8AE09AC07AF245D1888A620FAF97DE8084F4141D5F2107BEB09FC7F57073EAE8746A000A0DFFD507C79ED055A3",
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 1, 2, 16, 6, 51, 495, DateTimeKind.Unspecified).AddTicks(4080), new TimeSpan(0, 1, 0, 0, 0)),
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

            modelBuilder.Entity("Deerlicious.API.Database.Entities.RolePolicy", b =>
                {
                    b.HasOne("Deerlicious.API.Database.Entities.Policy", "Policy")
                        .WithMany("Roles")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deerlicious.API.Database.Entities.Role", "Role")
                        .WithMany("Policies")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Policy");

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

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Policy", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Deerlicious.API.Database.Entities.Role", b =>
                {
                    b.Navigation("Policies");

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
