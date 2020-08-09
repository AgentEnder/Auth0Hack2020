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
    public class SectionMetadataDTO
    {
        public Guid SectionId { get; set; }
        public Guid OfficeId { get; set; }        
        public string SectionName { get; set; }
        public string OfficeName { get; set; }
        public string SectionDescription { get; set; }
        public int SectionMaxCapacity { get; set; }
        public int SectionSafeCapacity { get; set; }  

        public static Expression<Func<Section, SectionMetadataDTO>> MapToDTO = (v) =>
        new SectionMetadataDTO
        {
            SectionId = v.SectionId,
            SectionName = v.SectionName,
            OfficeId = v.OfficeId,
            OfficeName = v.Office != null ? v.Office.OfficeName : "",
            SectionMaxCapacity = v.SectionMaxCapacity,
            SectionSafeCapacity = v.SectionSafeCapacity,
            SectionDescription = v.SectionDescription
        };

        public static Expression<Func<SectionMetadataDTO, Section>> MapToBase = (v) =>
        new Section
        {
            SectionId = v.SectionId,
            SectionName = v.SectionName,
            OfficeId = v.OfficeId,            
            SectionMaxCapacity = v.SectionMaxCapacity,
            SectionSafeCapacity = v.SectionSafeCapacity,
            SectionDescription = v.SectionDescription
        };

        public static SectionMetadataDTO MapToDTOFunc(Section s) {
            return MapToDTO.Compile().Invoke(s);
        }

        public static Section MapToBaseFunc(SectionMetadataDTO s)
        {
            return MapToBase.Compile().Invoke(s);
        }
    }
}
