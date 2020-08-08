using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Model
{
    public class ApprovalStatus
    {
        public Guid ApprovalStatusId { get; set; }
        public string StatusName { get; set; }
        public bool IsFinal { get; set; }
        public virtual ICollection<WorkRequest> WorkRequests { get; set; }
    }
}
