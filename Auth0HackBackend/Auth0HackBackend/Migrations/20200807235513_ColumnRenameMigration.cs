using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0HackBackend.Migrations
{
    public partial class ColumnRenameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionName",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "MaxCapacity",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "SafeCapacity",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "OfficeAddress",
                table: "Offices");

            migrationBuilder.AddColumn<string>(
                name: "SectionDescription",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionMaxCapacity",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectionSafeCapacity",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectionDescription",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "SectionMaxCapacity",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "SectionSafeCapacity",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionName",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxCapacity",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SafeCapacity",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OfficeAddress",
                table: "Offices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
