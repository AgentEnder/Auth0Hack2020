using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.DTO
{
    public class WorkRequestDetailDTO
    {
        public Guid WorkRequestId { get; set; }
        public EmployeeMetadataDTO Requestor { get; set; }

        public EmployeeMetadataDTO Approver { get; set; }
        public EmployeeMetadataDTO Person { get; set; }
        public OfficeMetadataDTO Office { get; set; }
        public int OfficeUsedCapacity { get; set; }
        public SectionMetadataDTO Section { get; set; }
        public int SectionUsedCapacity { get; set; }
        public ApprovalStatusMetadataDTO ApprovalStatus { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public string RequestorNotes { get; set; }
        public string ApproverNotes { get; set; }
    }
}
