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
    public class SectionDetailDTO
    {
        public Guid SectionId { get; set; }
        public string SectionName { get; set; }
        public string SectionDescription { get; set; }
        public int SectionMaxCapacity { get; set; }
        public int SectionSafeCapacity { get; set; }
        public int SectionUsedCapacity { get; set; }

        public static Expression<Func<Section, SectionDetailDTO>> MapToDTO = (v) =>
        new SectionDetailDTO
        {
            SectionId = v.SectionId,
            SectionName = v.SectionName,
            SectionMaxCapacity = v.SectionMaxCapacity,
            SectionSafeCapacity = v.SectionSafeCapacity,
            SectionDescription = v.SectionDescription            
        };

        public static Expression<Func<SectionDetailDTO, Section>> MapToBase = (v) =>
        new Section
        {
            SectionId = v.SectionId,
            SectionName = v.SectionName,
            SectionMaxCapacity = v.SectionMaxCapacity,
            SectionSafeCapacity = v.SectionSafeCapacity,
            SectionDescription = v.SectionDescription
        };

        public static SectionDetailDTO MapToDTOFunc(Section s) {
            return MapToDTO.Compile().Invoke(s);
        }

        public static Section MapToBaseFunc(SectionDetailDTO s)
        {
            return MapToBase.Compile().Invoke(s);
        }
    }
}
