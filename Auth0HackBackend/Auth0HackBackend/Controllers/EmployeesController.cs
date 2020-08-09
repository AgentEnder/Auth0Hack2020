using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Auth0HackBackend.DTO;
using Auth0HackBackend.Repositories;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth0HackBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        EmployeesRepository Repository { get; }
        public EmployeesController(EmployeesRepository EmployeesRepository)
        {
            Repository = EmployeesRepository;
        }

        [HttpGet()] // .../api/employees
        [EnableQuery(EnsureStableOrdering = false)]
        public IQueryable<EmployeeMetadataDTO> RetrieveEmployees()
        {
            return Repository.GetEmployeeMetadata();
        }

        [HttpPost("")] // .../api/employees
        [Authorize]
        [ScopeAuthorize("create:Employee")]
        public EmployeeMetadataDTO UpdateOrCreateEmployee([FromBody] EmployeeMetadataDTO employeeDTO)
        {
            return Repository.UpdateOrCreateEmployee(employeeDTO);
        }

        [HttpGet("by-id/{employeeId}")] // .../api/employees/by-id/{employeeId}
        public ValueTask<EmployeeMetadataDTO> GetEmployeeById([FromRoute] Guid employeeId)
        {
            return Repository.GetEmployeeById(employeeId);
        }

        [HttpGet("current-user")] // .../api/employees/current-user        
        public EmployeeMetadataDTO GetCurrentUser()
        {
            try
            {
                return Repository.GetEmployeeByAuthId(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
        
        [HttpGet("contact-trace/{employeeId}/{startTime}/{endTime}")] // .../api/employees/contact-trace/{employeeId}
        public List<EmployeeContactTraceDTO> ContactTraceByEmployee([FromRoute] Guid employeeId, [FromRoute] DateTimeOffset startTime, [FromRoute] DateTimeOffset endTime)
        {
            try
            {
                return Repository.ContactTraceByEmployee(employeeId, startTime, endTime);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
        
    }    
    
}
