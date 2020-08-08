﻿using System;
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
    public class WorkRequestUsedCountDTO
    {
        public Guid WorkRequestId { get; set; }
        public int OfficeUsedCount { get; set; }
        public int? SectionUsed { get; set; }        
    }
}
