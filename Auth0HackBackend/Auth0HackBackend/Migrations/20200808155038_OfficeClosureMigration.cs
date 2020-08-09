using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0HackBackend.Migrations
{
    public partial class OfficeClosureMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkRequests_ApprovalStatus_ApprovalStatusId",
                table: "WorkRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkRequests_Employees_RequestorId",
                table: "WorkRequests");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestorId",
                table: "WorkRequests",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApprovalStatusId",
                table: "WorkRequests",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "OfficeClosure",
                columns: table => new
                {
                    OfficeClosureId = table.Column<Guid>(nullable: false),
                    OfficeId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTimeOffset>(nullable: false),
                    EndTime = table.Column<DateTimeOffset>(nullable: false),
                    Descripton = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeClosure", x => x.OfficeClosureId);
                });

            migrationBuilder.CreateTable(
                name: "SectionClosure",
                columns: table => new
                {
                    SectionClosureId = table.Column<Guid>(nullable: false),
                    OfficeId = table.Column<Guid>(nullable: false),
                    SectionId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTimeOffset>(nullable: false),
                    EndTime = table.Column<DateTimeOffset>(nullable: false),
                    Descripton = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionClosure", x => x.SectionClosureId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkRequests_ApprovalStatus_ApprovalStatusId",
                table: "WorkRequests",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatus",
                principalColumn: "ApprovalStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkRequests_Employees_RequestorId",
                table: "WorkRequests",
                column: "RequestorId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkRequests_ApprovalStatus_ApprovalStatusId",
                table: "WorkRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkRequests_Employees_RequestorId",
                table: "WorkRequests");

            migrationBuilder.DropTable(
                name: "OfficeClosure");

            migrationBuilder.DropTable(
                name: "SectionClosure");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestorId",
                table: "WorkRequests",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApprovalStatusId",
                table: "WorkRequests",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkRequests_ApprovalStatus_ApprovalStatusId",
                table: "WorkRequests",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatus",
                principalColumn: "ApprovalStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkRequests_Employees_RequestorId",
                table: "WorkRequests",
                column: "RequestorId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}
