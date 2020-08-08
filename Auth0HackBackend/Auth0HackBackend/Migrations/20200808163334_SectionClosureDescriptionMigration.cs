using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0HackBackend.Migrations
{
    public partial class SectionClosureDescriptionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SectionClosure",
                table: "SectionClosure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficeClosure",
                table: "OfficeClosure");

            migrationBuilder.DropColumn(
                name: "Descripton",
                table: "SectionClosure");

            migrationBuilder.RenameTable(
                name: "SectionClosure",
                newName: "SectionClosures");

            migrationBuilder.RenameTable(
                name: "OfficeClosure",
                newName: "OfficeClosures");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SectionClosures",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SectionClosures",
                table: "SectionClosures",
                column: "SectionClosureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficeClosures",
                table: "OfficeClosures",
                column: "OfficeClosureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SectionClosures",
                table: "SectionClosures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficeClosures",
                table: "OfficeClosures");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SectionClosures");

            migrationBuilder.RenameTable(
                name: "SectionClosures",
                newName: "SectionClosure");

            migrationBuilder.RenameTable(
                name: "OfficeClosures",
                newName: "OfficeClosure");

            migrationBuilder.AddColumn<string>(
                name: "Descripton",
                table: "SectionClosure",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SectionClosure",
                table: "SectionClosure",
                column: "SectionClosureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficeClosure",
                table: "OfficeClosure",
                column: "OfficeClosureId");
        }
    }
}
