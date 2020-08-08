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

        [HttpGet()] // .../api/Employees
        [EnableQuery(EnsureStableOrdering = false)]
        public IQueryable<EmployeeMetadataDTO> RetrieveEmployees()
        {
            return Repository.GetEmployeeMetadata();
        }

        [HttpGet("by-id/{EmployeeId}")] // .../api/employees/by-id/{EmployeeId}
        public ValueTask<EmployeeMetadataDTO> GetEmployeeById([FromRoute] Guid EmployeeId)
        {
            return Repository.GetEmployeeById(EmployeeId);
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
    }    
}
