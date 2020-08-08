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
    public class WorkRequestMetadataDTO
    {
        public Guid WorkRequestId { get; set; }
        public EmployeeMetadataDTO Requestor { get; set; }
        public EmployeeMetadataDTO Approver { get; set; }
        public EmployeeMetadataDTO Person { get; set; }
        public OfficeMetadataDTO Office { get; set; }
        public Section Section { get; set; }
        public ApprovalStatusMetadataDTO ApprovalStatus { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }

        public static Expression<Func<WorkRequest, WorkRequestMetadataDTO>> MapToDTO = (v) =>
        new WorkRequestMetadataDTO
        {
            WorkRequestId = v.WorkRequestId,
            Requestor = v.Requestor != null ? EmployeeMetadataDTO.MapToDTOFunc(v.Requestor) : null,
            Approver = v.Approver != null ? EmployeeMetadataDTO.MapToDTOFunc(v.Approver) : null,
            Person = v.Person != null ? EmployeeMetadataDTO.MapToDTOFunc(v.Person) : null,
            Office = v.Office != null ? OfficeMetadataDTO.MapToDTOFunc(v.Office) : null,
            Section = v.Section,
            ApprovalStatus = v.ApprovalStatus != null ? ApprovalStatusMetadataDTO.MapToDTOFunc(v.ApprovalStatus) : null,
            StartTime = v.StartTime,
            EndTime = v.EndTime
        };

        public static Expression<Func<WorkRequestMetadataDTO, WorkRequest>> MapToBase = (v) =>
        new WorkRequest
        {
            WorkRequestId = v.WorkRequestId,
            RequestorId = v.Requestor.EmployeeId,
            ApproverId = v.Approver != null ? v.Approver.EmployeeId : Guid.Empty,               
            PersonId = v.Person.EmployeeId,
            OfficeId = v.Office.OfficeId,
            SectionId = v.Section.SectionId,
            ApprovalStatusId = v.ApprovalStatus.ApprovalStatusId,
            StartTime = v.StartTime.Value,
            EndTime = v.EndTime.Value
        };

        public static WorkRequestMetadataDTO MapToDTOFunc(WorkRequest wr) {
            return MapToDTO.Compile().Invoke(wr);
        }

        public static WorkRequest MapToBaseFunc(WorkRequestMetadataDTO wr)
        {
            return MapToBase.Compile().Invoke(wr);
        }
    }
}
