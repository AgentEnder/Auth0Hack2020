using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0HackBackend.Migrations
{
    public partial class vOfficeDateCapacities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

create view vOfficeDateCapacities as
select o.OfficeId,
       s.SectionId,
       o.OfficeName,
       s.SectionName,
       isnull(min(vWRC.OfficeUsedCapacity), 0) as OfficeUsedCapacity,
       isnull(min(vWRC.SectionUsedCapacity), 0) as SectionUsedCapacity,
       wr.StartTime
from Offices o
left join Sections s on s.OfficeId = o.OfficeId
inner join WorkRequests WR on o.OfficeId = WR.OfficeId and s.SectionId = wr.SectionId
inner join vWorkRequestCapacities vWRC on WR.WorkRequestId = vWRC.WorkRequestId
group by StartTime, s.SectionId, o.OfficeId, o.OfficeName, s.SectionName

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

drop view vOfficeDateCapacities

");
        }
    }
}
