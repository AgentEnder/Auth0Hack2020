using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0HackBackend.Migrations
{
    public partial class vWorkRequestCapacities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

CREATE VIEW vWorkRequestCapacities as
select
    wr.WorkRequestId,
    isnull((select sum(1)
     from WorkRequests officeRequests
     inner join ApprovalStatus orStatus on officeRequests.ApprovalStatusId = orStatus.ApprovalStatusId
     where officeRequests.OfficeId = wr.OfficeId
        and officeRequests.StartTime = wr.StartTime
        and orStatus.StatusName='Approved'),0) as OfficeUsedCapacity,
    isnull ((select sum(1)
     from WorkRequests officeRequests
     inner join ApprovalStatus orStatus on officeRequests.ApprovalStatusId = orStatus.ApprovalStatusId
     where officeRequests.SectionId = wr.SectionId
       and officeRequests.StartTime = wr.StartTime
        and orStatus.StatusName='Approved'),0) as SectionUsedCapacity
from WorkRequests wr

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

DROP VIEW vWorkRequestCapacities

");
        }
    }
}
