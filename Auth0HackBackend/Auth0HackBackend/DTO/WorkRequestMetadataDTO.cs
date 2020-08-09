using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public Guid WorkRequestId { get; set; }
        public EmployeeMetadataDTO Requestor { get; set; }

        public EmployeeMetadataDTO Approver { get; set; }
        public EmployeeMetadataDTO Person { get; set; }
        public OfficeMetadataDTO Office { get; set; }
        public SectionMetadataDTO Section { get; set; }
        public ApprovalStatusMetadataDTO ApprovalStatus { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public string RequestorNotes { get; set; }
        public string ApproverNotes { get; set; }

        public static Expression<Func<WorkRequest, WorkRequestMetadataDTO>> MapToDTO = (v) =>
        new WorkRequestMetadataDTO
        {
            WorkRequestId = v.WorkRequestId,
            Requestor = v.Requestor != null ? EmployeeMetadataDTO.MapToDTOFunc(v.Requestor) : null,
            Approver = v.Approver != null ? EmployeeMetadataDTO.MapToDTOFunc(v.Approver) : null,
            Person = v.Person != null ? EmployeeMetadataDTO.MapToDTOFunc(v.Person) : null,
            Office = v.Office != null ? OfficeMetadataDTO.MapToDTOFunc(v.Office) : null,
            Section = v.Section != null ? SectionMetadataDTO.MapToDTOFunc(v.Section) : null,
            ApprovalStatus = v.ApprovalStatus != null ? ApprovalStatusMetadataDTO.MapToDTOFunc(v.ApprovalStatus) : null,
            StartTime = v.StartTime,
            EndTime = v.EndTime,
            RequestorNotes = v.RequestorNotes,
            ApproverNotes = v.ApproverNotes
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
            EndTime = v.EndTime.Value,
            RequestorNotes = v.RequestorNotes,
            ApproverNotes = v.ApproverNotes
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
