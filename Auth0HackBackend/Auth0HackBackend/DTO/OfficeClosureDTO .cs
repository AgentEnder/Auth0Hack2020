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
    public class OfficeClosureDTO
    {
        public Guid OfficeClosureId { get; set; }
        public Guid OfficeId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string Description { get; set; }

        public static Expression<Func<OfficeClosure, OfficeClosureDTO>> MapToDTO = (v) =>
        new OfficeClosureDTO
        {
            Description = v.Description,
            EndTime = v.EndTime,
            OfficeClosureId = v.OfficeClosureId,
            OfficeId = v.OfficeId,
            StartTime = v.StartTime
        };

        public static Expression<Func<OfficeClosureDTO, OfficeClosure>> MapToBase = (v) =>
        new OfficeClosure
        {
            Description = v.Description,
            EndTime = v.EndTime,
            OfficeClosureId = v.OfficeClosureId,
            OfficeId = v.OfficeId,
            StartTime = v.StartTime
        };

        public static OfficeClosureDTO MapToDTOFunc(OfficeClosure o) {
            return MapToDTO.Compile().Invoke(o);
        }

        public static OfficeClosure MapToBaseFunc(OfficeClosureDTO o)
        {
            return MapToBase.Compile().Invoke(o);
        }
    }
}
