using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0HackBackend.Migrations
{
    public partial class AddAvatarMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Employees");
        }
    }
}
