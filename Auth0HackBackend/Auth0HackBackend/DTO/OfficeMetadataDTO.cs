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
    public class OfficeMetadataDTO
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

        public static Expression<Func<Office, OfficeMetadataDTO>> MapToDTO = (v) =>
        new OfficeMetadataDTO
        {
            OfficeMaxCapacity = v.OfficeMaxCapacity,
            OfficeSafeCapacity = v.OfficeSafeCapacity,
            OfficeCity = v.OfficeCity,
            OfficeId = v.OfficeId,
            OfficeName = v.OfficeName,
            OfficeState = v.OfficeState,
            OfficeStreet = v.OfficeStreet,
            OfficeZip = v.OfficeZip
        };

        public static Expression<Func<OfficeMetadataDTO, Office>> MapToBase = (v) =>
        new Office
        {
            OfficeMaxCapacity = v.OfficeMaxCapacity,
            OfficeSafeCapacity = v.OfficeSafeCapacity,
            OfficeCity = v.OfficeCity,
            OfficeId = v.OfficeId,
            OfficeName = v.OfficeName,
            OfficeState = v.OfficeState,
            OfficeStreet = v.OfficeStreet,
            OfficeZip = v.OfficeZip
        };

        public static OfficeMetadataDTO MapToDTOFunc(Office o) {
            return MapToDTO.Compile().Invoke(o);
        }

        public static Office MapToBaseFunc(OfficeMetadataDTO o)
        {
            return MapToBase.Compile().Invoke(o);
        }
    }
}
