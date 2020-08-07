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
        public Office Office { get; set; }       
        public int MaxCapacity { get; set; }
        public string SectionName { get; set; }
        public string DescriptionName { get; set; }        
    }
}
