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
    public class SectionClosureDTO
    {
        public Guid SectionClosureId { get; set; }
        public Guid OfficeId { get; set; }
        public Guid SectionId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string Description { get; set; }

        public static Expression<Func<SectionClosure, SectionClosureDTO>> MapToDTO = (v) =>
        new SectionClosureDTO
        {
            Description = v.Description,
            EndTime = v.EndTime,
            SectionClosureId = v.SectionClosureId,
            OfficeId = v.OfficeId,
            SectionId = v.SectionId,
            StartTime = v.StartTime
        };

        public static Expression<Func<SectionClosureDTO, SectionClosure>> MapToBase = (v) =>
        new SectionClosure
        {
            Description = v.Description,
            EndTime = v.EndTime,
            SectionClosureId = v.SectionClosureId,
            OfficeId = v.OfficeId,
            SectionId = v.SectionId,
            StartTime = v.StartTime
        };

        public static SectionClosureDTO MapToDTOFunc(SectionClosure sc) {
            return MapToDTO.Compile().Invoke(sc);
        }

        public static SectionClosure MapToBaseFunc(SectionClosureDTO sc)
        {
            return MapToBase.Compile().Invoke(sc);
        }
    }
}
