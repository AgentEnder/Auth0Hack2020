using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0HackBackend.Migrations
{
    public partial class WRNotesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApproverNotes",
                table: "WorkRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestorNotes",
                table: "WorkRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproverNotes",
                table: "WorkRequests");

            migrationBuilder.DropColumn(
                name: "RequestorNotes",
                table: "WorkRequests");
        }
    }
}
