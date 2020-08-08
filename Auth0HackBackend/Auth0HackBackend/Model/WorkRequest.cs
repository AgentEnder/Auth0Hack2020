using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Model
{
    public class WorkRequest
    {
        public Guid WorkRequestId { get; set; }
        public Guid RequestorId { get; set; }
        public virtual Employee Requestor { get; set; }
        public Guid PersonId { get; set; }
        public virtual Employee Person { get; set; }
        public Guid? ApproverId { get; set; }
        public virtual Employee Approver { get; set; }
        public Guid OfficeId { get; set; }
        public Office Office { get; set; }
        public Guid? SectionId { get; set; }
        public Section Section { get; set; }
        public Guid? ApprovalStatusId { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
    }
}
