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
    public class OfficesController : ControllerBase
    {
        OfficesRepository Repository { get; }
        public OfficesController(OfficesRepository officesRepository)
        {
            Repository = officesRepository;
        }

        [HttpGet()] // .../api/offices
        [EnableQuery(EnsureStableOrdering = false)]
        public IQueryable<OfficeMetadataDTO> RetrieveOffices()
        {
            return Repository.GetOfficeMetadata();
        }

        [HttpGet("by-id/{officeId}")] // .../api/offices/by-id/{id}
        public ValueTask<OfficeMetadataDTO> GetOfficeById([FromRoute] Guid officeId)
        {
            return Repository.GetOfficeById(officeId);
        }

        [HttpGet("by-id/{officeId}/{workDate}")] // .../api/offices/by-id/{id}/{date}
        public OfficeDetailDTO GetOfficeDetailById([FromRoute] Guid officeId, [FromRoute] DateTimeOffset workDate)
        {
            return Repository.GetOfficeDetailById(officeId, workDate);
        }

        [HttpGet("by-id/{officeId}/{startTime}/{endTime}")] // .../api/offices/by-id/{id}/{date}
        public List<OfficeDetailDTO> GetOfficeDetailByIdAndDateRange([FromRoute] Guid officeId, [FromRoute] DateTimeOffset startTime, DateTimeOffset endTime)
        {
            List<OfficeDetailDTO> retObj = new List<OfficeDetailDTO>();
            for (DateTimeOffset workDate = startTime; workDate < endTime; workDate = workDate.AddDays(1))
            {
                retObj.Add(GetOfficeDetailById(officeId, workDate));
            }
            return retObj;
        }
    }
}
