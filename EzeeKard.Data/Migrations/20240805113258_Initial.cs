using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EzeeKards.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Error",
                columns: table => new
                {
                    ErrorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorType = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Error", x => x.ErrorId);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialMediaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientExtraInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CMapUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSocialMedias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientExtraInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientExtraInfo_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Company_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyExtraInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMedias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyExtraInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyExtraInfo_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllClientDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientExtraInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyExtraInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllClientDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllClientDetails_ClientExtraInfo_ClientExtraInfoId",
                        column: x => x.ClientExtraInfoId,
                        principalTable: "ClientExtraInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllClientDetails_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllClientDetails_CompanyExtraInfo_CompanyExtraInfoId",
                        column: x => x.CompanyExtraInfoId,
                        principalTable: "CompanyExtraInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllClientDetails_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SocialMedia",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "LogoUrl", "SocialMediaName", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2024, 8, 5, 17, 17, 57, 311, DateTimeKind.Local).AddTicks(7460), false, "", "Facebook", null, new DateTime(2024, 8, 5, 17, 17, 57, 312, DateTimeKind.Local).AddTicks(8318) },
                    { 2, "", new DateTime(2024, 8, 5, 17, 17, 57, 312, DateTimeKind.Local).AddTicks(9515), false, "", "Instagram", null, new DateTime(2024, 8, 5, 17, 17, 57, 312, DateTimeKind.Local).AddTicks(9518) },
                    { 3, "", new DateTime(2024, 8, 5, 17, 17, 57, 312, DateTimeKind.Local).AddTicks(9521), false, "", "Viber", null, new DateTime(2024, 8, 5, 17, 17, 57, 312, DateTimeKind.Local).AddTicks(9521) },
                    { 4, "", new DateTime(2024, 8, 5, 17, 17, 57, 312, DateTimeKind.Local).AddTicks(9522), false, "", "Whatsapp", null, new DateTime(2024, 8, 5, 17, 17, 57, 312, DateTimeKind.Local).AddTicks(9523) },
                    { 5, "", new DateTime(2024, 8, 5, 17, 17, 57, 312, DateTimeKind.Local).AddTicks(9524), false, "", "Twitter", null, new DateTime(2024, 8, 5, 17, 17, 57, 312, DateTimeKind.Local).AddTicks(9524) },
                    { 6, "", new DateTime(2024, 8, 5, 17, 17, 57, 312, DateTimeKind.Local).AddTicks(9525), false, "", "LinkedIn", null, new DateTime(2024, 8, 5, 17, 17, 57, 312, DateTimeKind.Local).AddTicks(9525) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllClientDetails_ClientExtraInfoId",
                table: "AllClientDetails",
                column: "ClientExtraInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AllClientDetails_ClientId",
                table: "AllClientDetails",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AllClientDetails_CompanyExtraInfoId",
                table: "AllClientDetails",
                column: "CompanyExtraInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AllClientDetails_CompanyId",
                table: "AllClientDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientExtraInfo_ClientId",
                table: "ClientExtraInfo",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ClientId",
                table: "Company",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyExtraInfo_CompanyId",
                table: "CompanyExtraInfo",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllClientDetails");

            migrationBuilder.DropTable(
                name: "Error");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "ClientExtraInfo");

            migrationBuilder.DropTable(
                name: "CompanyExtraInfo");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
