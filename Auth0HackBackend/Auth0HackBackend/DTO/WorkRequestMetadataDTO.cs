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
        public string ApprovalStatus { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }

        public static Expression<Func<WorkRequest, WorkRequestMetadataDTO>> MapToDTO = (v) =>
        new WorkRequestMetadataDTO
        {
            WorkRequestId = v.WorkRequestId,
            Requestor = new EmployeeMetadataDTO
            {
                EmployeeId = v.Requestor.EmployeeId,
                FirstName = v.Requestor.FirstName,
                LastName = v.Requestor.LastName,
                Title = v.Requestor.Title
            },
            Approver = new EmployeeMetadataDTO
            {
                EmployeeId = v.Approver.EmployeeId,
                FirstName = v.Approver.FirstName,
                LastName = v.Approver.LastName,
                Title = v.Approver.Title
            },
            Person = new EmployeeMetadataDTO {
                EmployeeId = v.Person.EmployeeId,
                FirstName = v.Person.FirstName,
                LastName = v.Person.LastName,
                Title = v.Person.Title
            },
            Office = new OfficeMetadataDTO { 
                OfficeMaxCapacity = v.Office.OfficeMaxCapacity,
                OfficeSafeCapacity = v.Office.OfficeSafeCapacity,
                OfficeCity = v.Office.OfficeCity,
                OfficeLocation = v.Office.OfficeLocation,
                OfficeId = v.Office.OfficeId,
                OfficeName = v.Office.OfficeName,
                OfficeState = v.Office.OfficeState,
                OfficeStreet = v.Office.OfficeStreet,
                OfficeZip = v.Office.OfficeZip
            },
            Section = v.Section,
            ApprovalStatus = v.ApprovalStatus.StatusName,
            StartTime = v.StartTime,
            EndTime = v.EndTime
        };

        public static WorkRequestMetadataDTO MapToDTOFunc(WorkRequest wr) {
            return MapToDTO.Compile().Invoke(wr);
        }
    }
}
