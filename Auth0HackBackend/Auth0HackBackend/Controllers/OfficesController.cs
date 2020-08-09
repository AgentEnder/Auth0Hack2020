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

        [HttpGet("sections")] // .../api/offices/sections
        [EnableQuery(EnsureStableOrdering = false)]
        public IQueryable<SectionMetadataDTO> RetrieveSections()
        {
            return Repository.GetSectionMetadata();
        }

        [HttpGet("by-id/{OfficeId}")] // .../api/offices/by-id/{OfficeId}
        public ValueTask<OfficeMetadataDTO> GetOfficeById([FromRoute] Guid OfficeId)
        {
            return Repository.GetOfficeById(OfficeId);
        }

        [HttpGet("by-id/{OfficeId}/{WorkDate}")] // .../api/offices/by-id/{OfficeId}/{WorkDate}
        public async Task<OfficeDetailDTO> GetOfficeDetailById([FromRoute] Guid OfficeId, [FromRoute] DateTimeOffset WorkDate)
        {
            return await Repository.GetOfficeDetailById(OfficeId, WorkDate);
        }

        [HttpGet("by-id/{OfficeId}/{StartTime}/{EndTime}")] // .../api/offices/by-id/{id}/{date}
        public List<OfficeCountsDTO> GetOfficeDetailByIdAndDateRange([FromRoute] Guid officeId, [FromRoute] DateTimeOffset startTime, DateTimeOffset endTime)
        {            
            return GetOfficeDetailByIdAndDateRange(officeId, startTime, endTime);
        }

        [HttpGet("{WorkDate}")] // .../api/offices/{workDate}
        public async Task<IQueryable<OfficeDetailDTO>> GetOfficeDetailsByDate([FromRoute] DateTimeOffset WorkDate)
        {
            return await Repository.GetOfficeDetailsByDate(WorkDate);
        }
                
        [HttpPost("close")] // .../api/offices/close/{id}/{startTime}/{endTime}
        [ScopeAuthorize("create:OfficeClosure")]
        public OfficeClosureDTO CloseOffice([FromBody] OfficeClosureDTO officeClosureDTO)
        {
            return Repository.CloseOffice(officeClosureDTO);
        }

        [HttpPost("section/close")] // .../api/offices/close/{id}/{startTime}/{endTime}
        [ScopeAuthorize("create:SectionClosure")]
        public SectionClosureDTO CloseSection([FromBody] SectionClosureDTO sectionClosureDTO)
        {
            return Repository.CloseSection(sectionClosureDTO);
        }

        [HttpGet("office-section-used-count/{workRequestId}")] // .../api/offices/office-section-used-count/{workRequestId}
        public WorkRequestUsedCountDTO GetCountsForWorkRequest([FromBody] Guid workRequestId)
        {
            return Repository.GetCountsForWorkRequest(workRequestId);
        }

        [HttpPost("")] // .../api/offices
        [ScopeAuthorize("create:OfficeAndSection")]
        public OfficeMetadataDTO UpdateOrCreateOffice([FromBody] OfficeMetadataDTO officeDetailDTO)
        {
            return Repository.UpdateOrCreateOffice(officeDetailDTO);
        }

        [HttpPost("sections")] // .../api/offices/section
        [ScopeAuthorize("create:OfficeAndSection")]
        public SectionMetadataDTO UpdateOrCreateSection([FromBody] SectionMetadataDTO sectionDetailDTO)
        {
            return Repository.UpdateOrCreateSection(sectionDetailDTO);
        }
    }
}
