﻿// <auto-generated />
using System;
using Infrastructure.Persistence.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Migrations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230304084238_DocumentSeed")]
    partial class DocumentSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Base.TempId", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("#TempId");
                });

            modelBuilder.Entity("Domain.Documents.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Document");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Code = "A-93489",
                            Created = new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "John Doe",
                            IsActive = true,
                            LastModified = new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Jane Doe",
                            Title = "Buying some stuff"
                        },
                        new
                        {
                            Id = -2,
                            Code = "B-93847",
                            Created = new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Jane Doe",
                            IsActive = true,
                            LastModified = new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "John Doe",
                            Title = "Planning a trip"
                        },
                        new
                        {
                            Id = -3,
                            Code = "C-94857",
                            Created = new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "John Doe",
                            IsActive = false,
                            LastModified = new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Jane Doe",
                            Title = "Buying a car"
                        },
                        new
                        {
                            Id = -4,
                            Code = "D-85738",
                            Created = new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "John Doe",
                            IsActive = true,
                            LastModified = new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Jane Doe",
                            Title = "Traveling to Hawaii"
                        },
                        new
                        {
                            Id = -5,
                            Code = "E-11223",
                            Created = new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "John Doe",
                            IsActive = true,
                            LastModified = new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Jane Doe",
                            Title = "Organizing a trip"
                        },
                        new
                        {
                            Id = -6,
                            Code = "F-98546",
                            Created = new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Jane Doe",
                            IsActive = true,
                            LastModified = new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "John Doe",
                            Title = "Planning a vacation"
                        },
                        new
                        {
                            Id = -7,
                            Code = "E-34569",
                            Created = new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "John Doe",
                            IsActive = true,
                            LastModified = new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Jane Doe",
                            Title = "Organizing a party"
                        },
                        new
                        {
                            Id = -8,
                            Code = "F-65487",
                            Created = new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "John Doe",
                            IsActive = false,
                            LastModified = new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Jane Doe",
                            Title = "Planning a vacation"
                        },
                        new
                        {
                            Id = -9,
                            Code = "E-94748",
                            Created = new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "John Doe",
                            IsActive = true,
                            LastModified = new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Jane Doe",
                            Title = "Planning a trip to the moon"
                        },
                        new
                        {
                            Id = -10,
                            Code = "F-73848",
                            Created = new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "John Doe",
                            IsActive = false,
                            LastModified = new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Jane Doe",
                            Title = "Exploring new galaxies"
                        });
                });

            modelBuilder.Entity("Domain.Documents.Entities.DocumentDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("Solved")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("DocumentDetail");

                    b.HasData(
                        new
                        {
                            Id = -11,
                            Created = new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Tester X",
                            DocumentId = -1,
                            LastModified = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Tester X",
                            Priority = 3,
                            Solved = false,
                            Text = "Getting offers"
                        },
                        new
                        {
                            Id = -12,
                            Created = new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Me",
                            DocumentId = -2,
                            LastModified = new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "None",
                            Priority = 2,
                            Solved = false,
                            Text = "Talk to stakeholders"
                        },
                        new
                        {
                            Id = -21,
                            Created = new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Tester Y",
                            DocumentId = -2,
                            LastModified = new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Tester Y",
                            Priority = 3,
                            Solved = false,
                            Text = "Book flight tickets"
                        },
                        new
                        {
                            Id = -22,
                            Created = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Me",
                            DocumentId = -2,
                            LastModified = new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "None",
                            Priority = 1,
                            Solved = false,
                            Text = "Find accommodations"
                        },
                        new
                        {
                            Id = -31,
                            Created = new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Tester X",
                            DocumentId = -3,
                            LastModified = new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Tester X",
                            Priority = 3,
                            Solved = false,
                            Text = "Compare prices"
                        },
                        new
                        {
                            Id = -32,
                            Created = new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Me",
                            DocumentId = -3,
                            LastModified = new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "None",
                            Priority = 1,
                            Solved = false,
                            Text = "Arrange test drive"
                        },
                        new
                        {
                            Id = -41,
                            Created = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Tester X",
                            DocumentId = -4,
                            LastModified = new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Tester X",
                            Priority = 3,
                            Solved = false,
                            Text = "Book flights"
                        },
                        new
                        {
                            Id = -42,
                            Created = new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Me",
                            DocumentId = -4,
                            LastModified = new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "None",
                            Priority = 1,
                            Solved = false,
                            Text = "Book accommodation"
                        },
                        new
                        {
                            Id = -51,
                            Created = new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Tester X",
                            DocumentId = -5,
                            LastModified = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Tester X",
                            Priority = 3,
                            Solved = false,
                            Text = "Book flights"
                        },
                        new
                        {
                            Id = -52,
                            Created = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Me",
                            DocumentId = -5,
                            LastModified = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "None",
                            Priority = 1,
                            Solved = false,
                            Text = "Find accommodation"
                        },
                        new
                        {
                            Id = -61,
                            Created = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Tester X",
                            DocumentId = -6,
                            LastModified = new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Tester X",
                            Priority = 3,
                            Solved = false,
                            Text = "Research destinations"
                        },
                        new
                        {
                            Id = -62,
                            Created = new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Me",
                            DocumentId = -6,
                            LastModified = new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "None",
                            Priority = 1,
                            Solved = false,
                            Text = "Book flights"
                        },
                        new
                        {
                            Id = -71,
                            Created = new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Tester X",
                            DocumentId = -7,
                            LastModified = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Tester X",
                            Priority = 3,
                            Solved = false,
                            Text = "Find a venue"
                        },
                        new
                        {
                            Id = -72,
                            Created = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Me",
                            DocumentId = -7,
                            LastModified = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "None",
                            Priority = 1,
                            Solved = false,
                            Text = "Prepare guest list"
                        },
                        new
                        {
                            Id = -81,
                            Created = new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Tester X",
                            DocumentId = -8,
                            LastModified = new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Tester X",
                            Priority = 3,
                            Solved = false,
                            Text = "Research destinations"
                        },
                        new
                        {
                            Id = -82,
                            Created = new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Me",
                            DocumentId = -8,
                            LastModified = new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "None",
                            Priority = 1,
                            Solved = false,
                            Text = "Book flights"
                        },
                        new
                        {
                            Id = -91,
                            Created = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Tester X",
                            DocumentId = -9,
                            LastModified = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Tester X",
                            Priority = 3,
                            Solved = false,
                            Text = "Book a flight"
                        },
                        new
                        {
                            Id = -92,
                            Created = new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Me",
                            DocumentId = -9,
                            LastModified = new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "None",
                            Priority = 1,
                            Solved = false,
                            Text = "Find a good hotel"
                        },
                        new
                        {
                            Id = -101,
                            Created = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Tester X",
                            DocumentId = -10,
                            LastModified = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "Tester X",
                            Priority = 3,
                            Solved = false,
                            Text = "Find a spaceship"
                        },
                        new
                        {
                            Id = -102,
                            Created = new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "Me",
                            DocumentId = -10,
                            LastModified = new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedBy = "None",
                            Priority = 1,
                            Solved = false,
                            Text = "Gather supplies"
                        });
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Key", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DataProtected")
                        .HasColumnType("bit");

                    b.Property<bool>("IsX509Certificate")
                        .HasColumnType("bit");

                    b.Property<string>("Use")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Use");

                    b.ToTable("Keys", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Key");

                    b.HasIndex("ConsumedTime");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Documents.Entities.Document", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Color", "CategoryColor", b1 =>
                        {
                            b1.Property<int>("DocumentId")
                                .HasColumnType("int");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)")
                                .HasColumnName("CategoryColor");

                            b1.HasKey("DocumentId");

                            b1.ToTable("Document");

                            b1.WithOwner()
                                .HasForeignKey("DocumentId");
                        });

                    b.Navigation("CategoryColor");
                });

            modelBuilder.Entity("Domain.Documents.Entities.DocumentDetail", b =>
                {
                    b.HasOne("Domain.Documents.Entities.Document", "Document")
                        .WithMany("DocumentDetail")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Documents.Entities.Document", b =>
                {
                    b.Navigation("DocumentDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
