using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace Auth0HackBackend.Model
{
    public class Office
    {
        public Guid OfficeId { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public string OfficeName { get; set; }        
        public string OfficeStreet { get; set; }
        public string OfficeCity { get; set; }
        public string OfficeState { get; set; }
        public string OfficeZip { get; set; }
        public int OfficeMaxCapacity { get; set; }
        public int OfficeSafeCapacity { get; set; }
        public Point OfficeLocation { get; set; }
        public virtual ICollection<WorkRequest> WorkRequests { get; set; }
    }
}
