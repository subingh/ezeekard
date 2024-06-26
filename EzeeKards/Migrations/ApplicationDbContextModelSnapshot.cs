﻿// <auto-generated />
using System;
using EzeeKards.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EzeeKards.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EzeeKard.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("EzeeKard.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
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

                    b.ToTable("Company");
                });

            modelBuilder.Entity("EzeeKard.Models.ExtraInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MapUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SocialMedias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CompanyId");

                    b.ToTable("ExtraInfo");
                });

            modelBuilder.Entity("EzeeKard.Models.SocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
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
                            CreatedDate = new DateTime(2024, 6, 12, 17, 27, 51, 972, DateTimeKind.Local).AddTicks(8428),
                            IsDeleted = false,
                            LogoUrl = "",
                            SocialMediaName = "Facebook",
                            UpdatedDate = new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(1754)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3112),
                            IsDeleted = false,
                            LogoUrl = "",
                            SocialMediaName = "Instagram",
                            UpdatedDate = new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3115)
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3117),
                            IsDeleted = false,
                            LogoUrl = "",
                            SocialMediaName = "Viber",
                            UpdatedDate = new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3117)
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3118),
                            IsDeleted = false,
                            LogoUrl = "",
                            SocialMediaName = "Whatsapp",
                            UpdatedDate = new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3119)
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3119),
                            IsDeleted = false,
                            LogoUrl = "",
                            SocialMediaName = "Twitter",
                            UpdatedDate = new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3120)
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3121),
                            IsDeleted = false,
                            LogoUrl = "",
                            SocialMediaName = "LinkedIn",
                            UpdatedDate = new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3122)
                        });
                });

            modelBuilder.Entity("EzeeKard.Models.Company", b =>
                {
                    b.HasOne("EzeeKard.Models.Client", "Client")
                        .WithMany("Companies")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("EzeeKard.Models.ExtraInfo", b =>
                {
                    b.HasOne("EzeeKard.Models.Client", "Client")
                        .WithMany("ExtraInfos")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EzeeKard.Models.Company", "Company")
                        .WithMany("ExtraInfos")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("EzeeKard.Models.Client", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("ExtraInfos");
                });

            modelBuilder.Entity("EzeeKard.Models.Company", b =>
                {
                    b.Navigation("ExtraInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
