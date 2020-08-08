using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Model
{
    public class Section
    {
        public Guid SectionId { get; set; }
        public Guid OfficeId { get; set; }
        public virtual Office Office { get; set; }       
        public int SectionMaxCapacity { get; set; }
        public int SectionSafeCapacity { get; set; }
        public string SectionName { get; set; }
        public string SectionDescription { get; set; }      
        public virtual ICollection<WorkRequest> WorkRequests { get; set; }
    }
}
