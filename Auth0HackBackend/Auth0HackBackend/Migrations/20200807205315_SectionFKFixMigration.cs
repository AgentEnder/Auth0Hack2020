using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0HackBackend.Migrations
{
    public partial class SectionFKFixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Offices_SectionOfficeOfficeId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_SectionOfficeOfficeId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "SectionOfficeOfficeId",
                table: "Sections");

            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId",
                table: "Sections",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Sections_OfficeId",
                table: "Sections",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Offices_OfficeId",
                table: "Sections",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Offices_OfficeId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_OfficeId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Sections");

            migrationBuilder.AddColumn<Guid>(
                name: "SectionOfficeOfficeId",
                table: "Sections",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SectionOfficeOfficeId",
                table: "Sections",
                column: "SectionOfficeOfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Offices_SectionOfficeOfficeId",
                table: "Sections",
                column: "SectionOfficeOfficeId",
                principalTable: "Offices",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
