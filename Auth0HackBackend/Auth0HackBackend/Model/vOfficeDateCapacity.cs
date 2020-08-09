using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Model
{
    public class vOfficeDateCapacity
    {
        public Guid OfficeId { get; set; }
        public Guid SectionId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public int OfficeUsedCapacity { get; set; }
        public int SectionUsedCapacity { get; set; }
    }
}
