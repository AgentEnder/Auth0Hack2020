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
    public class ApprovalStatusMetadataDTO
    {
        public static Guid _APPROVED = Guid.Parse("B1575144-49A8-4C08-848A-152109006DCF");
        public static Guid _DENIED = Guid.Parse("2356F0A6-E5C6-4802-9704-31A6C16773A8");
        public static Guid _SUBMITTED = Guid.Parse("E54C2575-E6BD-4FD7-89AC-1D5A76DA7D07");
        public Guid ApprovalStatusId { get; set; }
        public string StatusName { get; set; }
        public bool IsFinal { get; set; }        

        public static Expression<Func<ApprovalStatus, ApprovalStatusMetadataDTO>> MapToDTO = (v) =>
        new ApprovalStatusMetadataDTO
        {
            ApprovalStatusId = v.ApprovalStatusId,
            StatusName = v.StatusName,
            IsFinal = v.IsFinal
        };

        public static Expression<Func<ApprovalStatusMetadataDTO, ApprovalStatus>> MapToBase = (v) =>
        new ApprovalStatus
        {
            ApprovalStatusId = v.ApprovalStatusId,
            StatusName = v.StatusName,
            IsFinal = v.IsFinal
        };
        public static ApprovalStatusMetadataDTO MapToDTOFunc(ApprovalStatus aps) {
            return MapToDTO.Compile().Invoke(aps);
        }

        public static ApprovalStatus MapToBaseFunc(ApprovalStatusMetadataDTO aps)
        {
            return MapToBase.Compile().Invoke(aps);
        }
    }
}
