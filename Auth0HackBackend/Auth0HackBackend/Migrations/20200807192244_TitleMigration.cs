using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0HackBackend.Migrations
{
    public partial class TitleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Employees");
        }
    }
}
