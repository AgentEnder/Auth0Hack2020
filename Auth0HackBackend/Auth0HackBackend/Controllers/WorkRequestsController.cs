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
    public class WorkRequestsController : ControllerBase
    {
        WorkRequestsRepository Repository { get; }
        public WorkRequestsController(WorkRequestsRepository WorkRequestsRepository)
        {
            Repository = WorkRequestsRepository;
        }

        [HttpGet()] // .../api/WorkRequests
        [EnableQuery(EnsureStableOrdering = false)]
        public IQueryable<WorkRequestMetadataDTO> RetrieveWorkRequests()
        {
            return Repository.GetWorkRequestMetadata();
        }

        [HttpGet("by-id/{id}")] // .../api/WorkRequests/by-id/{id}
        public ValueTask<WorkRequestMetadataDTO> GetWorkRequestById([FromRoute] Guid WorkRequestId)
        {
            return Repository.GetWorkRequestById(WorkRequestId);
        }

        [HttpPost()] // .../api/WorkRequests/by-employee-id/{id}
        public WorkRequestMetadataDTO GetWorkRequestByEmployeeId([FromRoute] WorkRequestMetadataDTO wr)
        {
            return Repository.SaveWorkRequest(wr);
        }
    }
}
