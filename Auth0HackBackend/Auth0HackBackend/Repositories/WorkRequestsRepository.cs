using Auth0HackBackend.DTO;
using Auth0HackBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Repositories
{
    public class WorkRequestsRepository
    {
        HackEntities DbContext { get; set; }

        public WorkRequestsRepository(HackEntities entities)
        {
            DbContext = entities;
        }

        public IQueryable<WorkRequestMetadataDTO> GetWorkRequestMetadata()
        {
            return DbContext.WorkRequests.Select(WorkRequestMetadataDTO.MapToDTO);
        }

        public async ValueTask<WorkRequestMetadataDTO> GetWorkRequestById(Guid WorkRequestId)
        {
            var workRequest = await DbContext.WorkRequests.FindAsync(WorkRequestId);
            return WorkRequestMetadataDTO.MapToDTOFunc(workRequest);
        }

        public IQueryable<WorkRequestMetadataDTO> GetWorkRequestsByEmployeeId(Guid EmployeeId)
        {
            return DbContext.WorkRequests.Where(x => x.PersonId == EmployeeId).Select(WorkRequestMetadataDTO.MapToDTO);
        }

        public WorkRequestMetadataDTO SaveWorkRequest(WorkRequestMetadataDTO wr)
        {
            WorkRequest newWorkRequest = null;

            if (wr.WorkRequestId != Guid.Empty) {
                newWorkRequest = DbContext.WorkRequests.Find(wr.WorkRequestId);
            }                            
            if (newWorkRequest != null) // Edit exsiting
            {
                newWorkRequest.ApproverId = wr.Approver.EmployeeId;
                newWorkRequest.EndTime = wr.EndTime != null ? wr.EndTime.Value : newWorkRequest.EndTime;
                newWorkRequest.OfficeId = wr.Office.OfficeId;
                newWorkRequest.PersonId = wr.Person.EmployeeId;
                newWorkRequest.RequestorId = wr.Requestor.EmployeeId;
                newWorkRequest.SectionId = wr.Section.SectionId;
                newWorkRequest.StartTime = wr.StartTime != null ? wr.StartTime.Value : newWorkRequest.StartTime;                
            } else // Create new request
            {
                newWorkRequest = WorkRequestMetadataDTO.MapToBaseFunc(wr);
                newWorkRequest.WorkRequestId = Guid.NewGuid();
                DbContext.Add(newWorkRequest);
            }
            
            DbContext.SaveChanges();

            return WorkRequestMetadataDTO.MapToDTOFunc(newWorkRequest);
        }
    }
}
