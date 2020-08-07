using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0HackBackend.Migrations
{
    public partial class WorkRequestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficeCapacity",
                table: "Offices");

            migrationBuilder.AddColumn<int>(
                name: "SafeCapacity",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfficeMaxCapacity",
                table: "Offices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfficeSafeCapacity",
                table: "Offices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApprovalStatus",
                columns: table => new
                {
                    ApprovalStatusId = table.Column<Guid>(nullable: false),
                    StatusName = table.Column<string>(nullable: true),
                    IsFinal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStatus", x => x.ApprovalStatusId);
                });

            migrationBuilder.CreateTable(
                name: "WorkRequests",
                columns: table => new
                {
                    WorkRequestId = table.Column<Guid>(nullable: false),
                    RequestorId = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    ApproverId = table.Column<Guid>(nullable: true),
                    OfficeId = table.Column<Guid>(nullable: false),
                    SectionId = table.Column<Guid>(nullable: true),
                    ApprovalStatusId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTimeOffset>(nullable: false),
                    EndTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkRequests", x => x.WorkRequestId);
                    table.ForeignKey(
                        name: "FK_WorkRequests_ApprovalStatus_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalTable: "ApprovalStatus",
                        principalColumn: "ApprovalStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkRequests_Employees_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_WorkRequests_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkRequests_Employees_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_WorkRequests_Employees_RequestorId",
                        column: x => x.RequestorId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_WorkRequests_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkRequests_ApprovalStatusId",
                table: "WorkRequests",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkRequests_ApproverId",
                table: "WorkRequests",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkRequests_OfficeId",
                table: "WorkRequests",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkRequests_PersonId",
                table: "WorkRequests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkRequests_RequestorId",
                table: "WorkRequests",
                column: "RequestorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkRequests_SectionId",
                table: "WorkRequests",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkRequests");

            migrationBuilder.DropTable(
                name: "ApprovalStatus");

            migrationBuilder.DropColumn(
                name: "SafeCapacity",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "OfficeMaxCapacity",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "OfficeSafeCapacity",
                table: "Offices");

            migrationBuilder.AddColumn<int>(
                name: "OfficeCapacity",
                table: "Offices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
