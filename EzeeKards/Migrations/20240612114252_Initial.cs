using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EzeeKards.Migrations
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExtraInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialMedias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraInfo_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtraInfo_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "SocialMedia",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "LogoUrl", "SocialMediaName", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 6, 12, 17, 27, 51, 972, DateTimeKind.Local).AddTicks(8428), false, "", "Facebook", null, new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(1754) },
                    { 2, null, new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3112), false, "", "Instagram", null, new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3115) },
                    { 3, null, new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3117), false, "", "Viber", null, new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3117) },
                    { 4, null, new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3118), false, "", "Whatsapp", null, new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3119) },
                    { 5, null, new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3119), false, "", "Twitter", null, new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3120) },
                    { 6, null, new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3121), false, "", "LinkedIn", null, new DateTime(2024, 6, 12, 17, 27, 51, 974, DateTimeKind.Local).AddTicks(3122) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_ClientId",
                table: "Company",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraInfo_ClientId",
                table: "ExtraInfo",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraInfo_CompanyId",
                table: "ExtraInfo",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraInfo");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
