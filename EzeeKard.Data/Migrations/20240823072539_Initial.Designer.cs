﻿// <auto-generated />
using System;
using EzeeKards.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EzeeKards.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240823072539_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EzeeKards.Data.Entities.Domain.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminName = "Surabin",
                            Email = "sghatuwal14@gmail.com",
                            FirstName = "Subindra",
                            LastName = "Ghatuwal",
                            Password = "Subingh9@"
                        });
                });

            modelBuilder.Entity("EzeeKards.Data.Entities.Domain.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("EzeeKards.Data.Entities.Domain.ClientExtraInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CMapUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CSocialMedias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CWebsite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientExtraInfo");
                });

            modelBuilder.Entity("EzeeKards.Data.Entities.Domain.Company", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CompanyId");

                    b.HasIndex("ClientId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("EzeeKards.Data.Entities.Domain.CompanyExtraInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MapUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SocialMedias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyExtraInfo");
                });

            modelBuilder.Entity("EzeeKards.Data.Entities.Domain.Error", b =>
                {
                    b.Property<long>("ErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ErrorId"));

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ErrorType")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("ErrorId");

                    b.ToTable("Error");
                });

            modelBuilder.Entity("EzeeKards.Data.Entities.Domain.SocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialMediaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SocialMedia");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 8, 23, 13, 10, 38, 486, DateTimeKind.Local).AddTicks(3093),
                            IsDeleted = false,
                            LogoUrl = "",
                            SocialMediaName = "Facebook",
                            UpdatedDate = new DateTime(2024, 8, 23, 13, 10, 38, 486, DateTimeKind.Local).AddTicks(3103)
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 8, 23, 13, 10, 38, 486, DateTimeKind.Local).AddTicks(3108),
                            IsDeleted = false,
                            LogoUrl = "",
                            SocialMediaName = "Instagram",
                            UpdatedDate = new DateTime(2024, 8, 23, 13, 10, 38, 486, DateTimeKind.Local).AddTicks(3109)
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 8, 23, 13, 10, 38, 486, DateTimeKind.Local).AddTicks(3110),
                            IsDeleted = false,
                            LogoUrl = "",
                            SocialMediaName = "Viber",
                            UpdatedDate = new DateTime(2024, 8, 23, 13, 10, 38, 486, DateTimeKind.Local).AddTicks(3110)
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 8, 23, 13, 10, 38, 486, DateTimeKind.Local).AddTicks(3111),
                            IsDeleted = false,
                            LogoUrl = "",
                            SocialMediaName = "Whatsapp",
                            UpdatedDate = new DateTime(2024, 8, 23, 13, 10, 38, 486, DateTimeKind.Local).AddTicks(3112)
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 8, 23, 13, 10, 38, 486, DateTimeKind.Local).AddTicks(3113),
                            IsDeleted = false,
                            LogoUrl = "",
                            SocialMediaName = "Twitter",
                            UpdatedDate = new DateTime(2024, 8, 23, 13, 10, 38, 486, DateTimeKind.Local).AddTicks(3113)
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "",
                            CreatedDate = new DateTime(2024, 8, 23, 13, 10, 38, 486, DateTimeKind.Local).AddTicks(3114),
                            IsDeleted = false,
                            LogoUrl = "",
                            SocialMediaName = "LinkedIn",
                            UpdatedDate = new DateTime(2024, 8, 23, 13, 10, 38, 486, DateTimeKind.Local).AddTicks(3115)
                        });
                });

            modelBuilder.Entity("EzeeKards.Data.Entities.Domain.ClientExtraInfo", b =>
                {
                    b.HasOne("EzeeKards.Data.Entities.Domain.Client", "Client")
                        .WithMany("ClientExtraInfos")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("EzeeKards.Data.Entities.Domain.Company", b =>
                {
                    b.HasOne("EzeeKards.Data.Entities.Domain.Client", "Client")
                        .WithMany("Companies")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("EzeeKards.Data.Entities.Domain.CompanyExtraInfo", b =>
                {
                    b.HasOne("EzeeKards.Data.Entities.Domain.Company", "Company")
                        .WithMany("CompanyExtraInfos")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("EzeeKards.Data.Entities.Domain.Client", b =>
                {
                    b.Navigation("ClientExtraInfos");

                    b.Navigation("Companies");
                });

            modelBuilder.Entity("EzeeKards.Data.Entities.Domain.Company", b =>
                {
                    b.Navigation("CompanyExtraInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
