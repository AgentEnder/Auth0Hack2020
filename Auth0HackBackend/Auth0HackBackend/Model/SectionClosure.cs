using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace Auth0HackBackend.Model
{
    public class SectionClosure
    {
        public Guid SectionClosureId { get; set; }
        public Guid OfficeId { get; set; }
        public Guid SectionId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string Descripton { get; set; }
    }
}
