using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Auth0HackBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

namespace Auth0HackBackend.DTO
{
    public class OfficeCountsDTO
    { 
        public Guid OfficeId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public int ApprovedCount { get; set; }
    }
}
