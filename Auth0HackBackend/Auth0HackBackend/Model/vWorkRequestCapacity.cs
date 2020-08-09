using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Model
{
    public class vWorkRequestCapacity
    {
        public Guid WorkRequestId { get; set; }
        public int OfficeUsedCapacity { get; set; }
        public int SectionUsedCapacity { get; set; }
    }
}
