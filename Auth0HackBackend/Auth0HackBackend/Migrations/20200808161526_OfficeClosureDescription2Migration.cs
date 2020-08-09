using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0HackBackend.Migrations
{
    public partial class OfficeClosureDescription2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripton",
                table: "OfficeClosure");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OfficeClosure",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "OfficeClosure");

            migrationBuilder.AddColumn<string>(
                name: "Descripton",
                table: "OfficeClosure",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
