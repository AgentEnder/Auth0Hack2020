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
    public class OfficeDetailDTO
    {
        public Guid OfficeId { get; set; }
        public string OfficeName { get; set; }
        public string OfficeAddress { get; set; }
        public string OfficeStreet { get; set; }
        public string OfficeCity { get; set; }
        public string OfficeState { get; set; }
        public string OfficeZip { get; set; }
        public int OfficeMaxCapacity { get; set; }
        public int OfficeSafeCapacity { get; set; }
        public int OfficeUsedCapacity { get; set; }        
        public DateTimeOffset SnapshotDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IEnumerable<SectionDetailDTO> Sections { get; set; }

        public static Expression<Func<Office, OfficeDetailDTO>> MapToDTO = (v) =>
        new OfficeDetailDTO
        {
            OfficeMaxCapacity = v.OfficeMaxCapacity,
            OfficeSafeCapacity = v.OfficeSafeCapacity,
            OfficeCity = v.OfficeCity,
            OfficeId = v.OfficeId,
            Latitude = v.OfficeLocation == null ? default : v.OfficeLocation.Y,
            Longitude = v.OfficeLocation == null ? default : v.OfficeLocation.X,
            OfficeName = v.OfficeName,
            OfficeState = v.OfficeState,
            OfficeStreet = v.OfficeStreet,
            OfficeZip = v.OfficeZip,
            Sections = v.Sections.AsQueryable().Select(SectionDetailDTO.MapToDTO)
        };

        public static Expression<Func<OfficeDetailDTO, Office>> MapToBase = (v) =>
        new Office
        {
            OfficeMaxCapacity = v.OfficeMaxCapacity,
            OfficeSafeCapacity = v.OfficeSafeCapacity,
            OfficeCity = v.OfficeCity,
            OfficeId = v.OfficeId,
            OfficeLocation = new Point(v.Longitude, v.Latitude),
            OfficeName = v.OfficeName,
            OfficeState = v.OfficeState,
            OfficeStreet = v.OfficeStreet,
            OfficeZip = v.OfficeZip
        };

        public static OfficeDetailDTO MapToDTOFunc(Office o) {
            return MapToDTO.Compile().Invoke(o);
        }

        public static Office MapToBaseFunc(OfficeDetailDTO o)
        {
            return MapToBase.Compile().Invoke(o);
        }
    }
}
