using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0HackBackend.Migrations
{
    public partial class OfficeAndSectionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeId = table.Column<Guid>(nullable: false),
                    OfficeName = table.Column<string>(nullable: true),
                    OfficeAddress = table.Column<string>(nullable: true),
                    OfficeStreet = table.Column<string>(nullable: true),
                    OfficeCity = table.Column<string>(maxLength: 60, nullable: true),
                    OfficeState = table.Column<string>(maxLength: 2, nullable: true),
                    OfficeZip = table.Column<string>(maxLength: 10, nullable: true),
                    OfficeCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeId);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<Guid>(nullable: false),
                    OfficeId = table.Column<Guid>(nullable: false),
                    MaxCapacity = table.Column<int>(nullable: false),
                    SectionName = table.Column<string>(nullable: true),
                    DescriptionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
