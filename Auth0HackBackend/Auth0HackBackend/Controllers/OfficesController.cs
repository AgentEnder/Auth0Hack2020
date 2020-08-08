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

        [HttpGet("by-id/{OfficeId}")] // .../api/offices/by-id/{OfficeId}
        public ValueTask<OfficeMetadataDTO> GetOfficeById([FromRoute] Guid OfficeId)
        {
            return Repository.GetOfficeById(OfficeId);
        }

        [HttpGet("by-id/{OfficeId}/{WorkDate}")] // .../api/offices/by-id/{OfficeId}/{WorkDate}
        public OfficeDetailDTO GetOfficeDetailById([FromRoute] Guid OfficeId, [FromRoute] DateTimeOffset WorkDate)
        {
            return Repository.GetOfficeDetailById(OfficeId, WorkDate);
        }

        [HttpGet("by-id/{OfficeId}/{StartTime}/{EndTime}")] // .../api/offices/by-id/{id}/{date}
        public List<OfficeDetailDTO> GetOfficeDetailByIdAndDateRange([FromRoute] Guid OfficeId, [FromRoute] DateTimeOffset StartTime, DateTimeOffset EndTime)
        {
            List<OfficeDetailDTO> retObj = new List<OfficeDetailDTO>();
            for (DateTimeOffset workDate = StartTime; workDate < EndTime; workDate = workDate.AddDays(1))
            {
                retObj.Add(GetOfficeDetailById(OfficeId, workDate));
            }
            return retObj;
        }

        [HttpGet("/{WorkDate}")] // .../api/offices/{workDate}
        public List<OfficeDetailDTO> GetOfficeDetailsByDate([FromRoute] DateTimeOffset WorkDate)
        {
            List<OfficeDetailDTO> retObj = new List<OfficeDetailDTO>();
            IQueryable<OfficeMetadataDTO> offices = Repository.GetOfficeMetadata();
            foreach (OfficeMetadataDTO office in offices)
            {
                retObj.Add(GetOfficeDetailById(office.OfficeId, WorkDate));
            }
            return retObj;
        }
        /*
        [HttpGet("/close/{id}/{startTime}/{endTime}")] // .../api/offices/close/{id}/{startTime}/{endTime}
        public OfficeClosure CloseOffice()
        {

        }
        */
    }
}
