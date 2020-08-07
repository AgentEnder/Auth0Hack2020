using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Auth0HackBackend.Migrations
{
    public partial class OfficeGeographyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Point>(
                name: "OfficeLocation",
                table: "Offices",
                type: "geography",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficeLocation",
                table: "Offices");
        }
    }
}
