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
        public string SectionName { get; set; }
        public string SectionDescription { get; set; }
        public int SectionMaxCapacity { get; set; }
        public int SectionSafeCapacity { get; set; }        

        public static Expression<Func<Section, SectionMetadataDTO>> MapToDTO = (v) =>
        new SectionMetadataDTO
        {
            SectionId = v.SectionId,
            SectionMaxCapacity = v.SectionMaxCapacity,
            SectionSafeCapacity = v.SectionSafeCapacity,
            SectionDescription = v.SectionDescription
        };

        public static SectionMetadataDTO MapToDTOFunc(Section o) {
            return MapToDTO.Compile().Invoke(o);
        }
    }
}
