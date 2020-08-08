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
