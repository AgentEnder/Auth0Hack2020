using Auth0HackBackend.DTO;
using Auth0HackBackend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Repositories
{
    public class EmployeesRepository
    {
        HackEntities DbContext { get; set; }

        public EmployeesRepository(HackEntities entities)
        {
            DbContext = entities;
        }

        public EmployeeMetadataDTO GetEmployeeByAuthId(string auth0Id)
        {
            var employee = DbContext.Employees.FirstOrDefault(x => x.Auth0Id == auth0Id);
            return EmployeeMetadataDTO.MapToDTOFunc(employee);
        }

        public IQueryable<EmployeeMetadataDTO> GetEmployeeMetadata()
        {
            return DbContext.Employees.Select(EmployeeMetadataDTO.MapToDTO);
        }

        public async ValueTask<EmployeeMetadataDTO> GetEmployeeById(Guid employeeId)
        {
            var employee = await DbContext.Employees.FindAsync(employeeId);
            return EmployeeMetadataDTO.MapToDTOFunc(employee);
        }

        public EmployeeMetadataDTO UpdateOrCreateEmployee(EmployeeMetadataDTO employeeDTO)
        {
            Employee newEmployee = null;

            if (employeeDTO.EmployeeId != Guid.Empty)
            {
                newEmployee = DbContext.Employees.Find(employeeDTO.EmployeeId);
            }
            if (newEmployee != null) // Edit existing
            {
                newEmployee.Avatar = employeeDTO.Avatar;
                newEmployee.Email = employeeDTO.Email;
                newEmployee.FirstName = employeeDTO.FirstName;
                newEmployee.isApprover = employeeDTO.isApprover;
                newEmployee.LastName = employeeDTO.LastName;
                newEmployee.Title = employeeDTO.Title;                
            }
            else // Create new Employee
            {
                newEmployee = EmployeeMetadataDTO.MapToBaseFunc(employeeDTO);
                newEmployee.EmployeeId = Guid.NewGuid();
                DbContext.Employees.Add(newEmployee);
            }

            DbContext.SaveChanges();

            return EmployeeMetadataDTO.MapToDTOFunc(newEmployee);
        }
        public List<EmployeeContactTraceDTO> ContactTraceByEmployee(Guid employeeId, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            List<EmployeeContactTraceDTO> retObj = new List<EmployeeContactTraceDTO>();
            List<WorkRequest> empWR = DbContext.WorkRequests.Where(x => x.PersonId == employeeId && 
                   x.ApprovalStatusId == ApprovalStatusMetadataDTO._APPROVED &&
                   ((x.StartTime >= startTime && x.EndTime <= endTime) ||
                    (x.EndTime >= startTime && x.EndTime <= endTime) ||
                    (startTime >= x.StartTime && startTime <= x.EndTime) ||
                    (endTime >= x.StartTime && endTime <= x.EndTime))
                   ).Include(x => x.Person)
                    .Include(x => x.Office)
                    .Include(x => x.Section)
                    .OrderBy(x => x.StartTime).ToList();

            foreach (WorkRequest wr in empWR) {
                List<WorkRequest> otherWRs = DbContext.WorkRequests.Where(x => x.PersonId != employeeId &&
                    x.ApprovalStatusId == ApprovalStatusMetadataDTO._APPROVED &&
                    x.OfficeId == wr.OfficeId && x.SectionId == wr.SectionId &&
                    ((x.StartTime >= wr.StartTime && x.EndTime <= wr.EndTime) ||
                    (x.EndTime >= wr.StartTime && x.EndTime <= wr.EndTime) ||
                    (wr.StartTime >= x.StartTime && wr.StartTime <= x.EndTime) ||
                    (wr.EndTime >= x.StartTime && wr.EndTime <= x.EndTime)))
                    .Include(x => x.Person)
                    .Include(x => x.Office)
                    .Include(x => x.Section).ToList();
                foreach (WorkRequest oWR in otherWRs)
                {
                    EmployeeContactTraceDTO ectDTO = new EmployeeContactTraceDTO();
                    ectDTO.DateOfContact = new DateTimeOffset(wr.StartTime.Year, wr.StartTime.Month, wr.StartTime.Day, 0, 0, 0, wr.StartTime.Offset);
                    ectDTO.EmployeeDTO = new EmployeeMetadataDTO
                    {
                        EmployeeId = oWR.PersonId,
                        Email = oWR.Person.Email,
                        FirstName = oWR.Person.FirstName,
                        LastName = oWR.Person.LastName,
                        Title = oWR.Person.Title
                    };
                    ectDTO.OfficeId = oWR.OfficeId;
                    ectDTO.OfficeName = oWR.Office.OfficeName;
                    ectDTO.SectionId = oWR.SectionId;
                    ectDTO.SectionName = oWR.Section.SectionName;

                    retObj.Add(ectDTO);
                }
            }

            return retObj;            
        }
        
    }
}
