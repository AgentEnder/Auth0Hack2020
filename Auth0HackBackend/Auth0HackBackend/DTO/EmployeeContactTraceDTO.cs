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
    public class EmployeeContactTraceDTO
    {
        public EmployeeMetadataDTO EmployeeDTO { get; set; }
        public DateTimeOffset DateOfContact;
        public Guid OfficeId;
        public string OfficeName;
        public Guid? SectionId;        
        public string SectionName;        
    }
}
