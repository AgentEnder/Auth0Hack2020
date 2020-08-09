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
        EmployeesRepository EmpRepository { get; }
        public WorkRequestsRepository(HackEntities entities, EmployeesRepository EmployeesRepository)
        {
            DbContext = entities;
            EmpRepository = EmployeesRepository;
        }

        public IQueryable<WorkRequestMetadataDTO> GetWorkRequestMetadata()
        {
            return DbContext.WorkRequests.Select(WorkRequestMetadataDTO.MapToDTO);
        }

        public IQueryable<WorkRequestDetailDTO> GetWorkRequestDetailDTOs()
        {
            return from request in DbContext.WorkRequests
                   join capacity in DbContext.vWorkRequestCapacities on request.WorkRequestId equals capacity.WorkRequestId
                   select new WorkRequestDetailDTO
                   {
                       Section = SectionMetadataDTO.MapToDTOFunc(request.Section),
                       ApprovalStatus = ApprovalStatusMetadataDTO.MapToDTOFunc(request.ApprovalStatus),
                       Approver = EmployeeMetadataDTO.MapToDTOFunc(request.Approver),
                       Person = EmployeeMetadataDTO.MapToDTOFunc(request.Person),
                       Requestor = EmployeeMetadataDTO.MapToDTOFunc(request.Requestor),
                       ApproverNotes = request.ApproverNotes,
                       EndTime = request.EndTime,
                       Office = OfficeMetadataDTO.MapToDTOFunc(request.Office),
                       OfficeUsedCapacity = capacity.OfficeUsedCapacity,
                       RequestorNotes = request.RequestorNotes,
                       SectionUsedCapacity = capacity.SectionUsedCapacity,
                       StartTime = request.StartTime,
                       WorkRequestId = request.WorkRequestId
                   };
        }

        public IQueryable<WorkRequestMetadataDTO> GetOwnWorkRequestMetadata(string auth0Id)
        {
            return DbContext.WorkRequests.Where(x =>
                   x.PersonId == EmpRepository.GetEmployeeByAuthId(auth0Id).EmployeeId).
                   Select(WorkRequestMetadataDTO.MapToDTO);
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

            if (wr.WorkRequestId != Guid.Empty)
            {
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
            }
            else // Create new request
            {
                newWorkRequest = WorkRequestMetadataDTO.MapToBaseFunc(wr);
                newWorkRequest.WorkRequestId = Guid.NewGuid();
                DbContext.Add(newWorkRequest);
            }

            DbContext.SaveChanges();

            return WorkRequestMetadataDTO.MapToDTOFunc(newWorkRequest);
        }

        public WorkRequest SetStatusAndApprover(Guid approvalStatusId, WorkRequestApprovalDTO wra, string auth0Id)
        {
            WorkRequest wr = DbContext.WorkRequests.Find(wra.WorkRequestId);
            if (wr != null)
            {
                wr.ApprovalStatus.ApprovalStatusId = approvalStatusId;
                wr.Approver.EmployeeId = EmpRepository.GetEmployeeByAuthId(auth0Id).EmployeeId;
                wr.ApproverNotes = wra.ApproverNotes;
            }

            DbContext.SaveChanges();

            return wr;
        }
        public WorkRequestMetadataDTO ApproveWorkRequest(WorkRequestApprovalDTO wra, string auth0Id)
        {
            WorkRequest wr = SetStatusAndApprover(ApprovalStatusMetadataDTO._APPROVED, wra, auth0Id);

            return WorkRequestMetadataDTO.MapToDTOFunc(wr);
        }

        public WorkRequestMetadataDTO DenyWorkRequest(WorkRequestApprovalDTO wra, string auth0Id)
        {
            WorkRequest wr = SetStatusAndApprover(ApprovalStatusMetadataDTO._DENIED, wra, auth0Id);

            return WorkRequestMetadataDTO.MapToDTOFunc(wr);
        }
    }
}
