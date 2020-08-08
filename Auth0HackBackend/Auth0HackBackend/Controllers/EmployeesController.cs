using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0HackBackend.DTO;
using Auth0HackBackend.Repositories;
using Microsoft.AspNet.OData;
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

        [HttpGet("by-id/{id}")] // .../api/Employees/by-id/{id}
        public ValueTask<EmployeeMetadataDTO> GetEmployeeById([FromRoute] Guid EmployeeId)
        {
            return Repository.GetEmployeeById(EmployeeId);
        }
    }
}
