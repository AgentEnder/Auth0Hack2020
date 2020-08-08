using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0HackBackend.DTO;
using Auth0HackBackend.Extensions;
using Auth0HackBackend.Repositories;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
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
        [ScopeAuthorize("read:WorkRequestsAll")]
        public IQueryable<WorkRequestMetadataDTO> RetrieveWorkRequests()
        {
            return Repository.GetWorkRequestMetadata();
        }

        [HttpGet()]
        [Authorize]
        [ScopeAuthorize("read:WorkRequestsSelf")]
        public IQueryable<WorkRequestMetadataDTO> GetOwnWorkRequests()
        {
            return Repository.GetOwnWorkRequestMetadata(User.getAuth0Id());
        }

        [HttpGet("by-id/{WorkRequestId}")] // .../api/WorkRequests/by-id/{WorkRequestId}
        [ScopeAuthorize("read:WorkRequestsAll")]
        public ValueTask<WorkRequestMetadataDTO> GetWorkRequestById([FromRoute] Guid WorkRequestId)
        {
            return Repository.GetWorkRequestById(WorkRequestId);
        }

        [HttpPost()] // .../api/WorkRequests/
        [Authorize]
        [ScopeAuthorize("create:WorkRequests")]
        public WorkRequestMetadataDTO SaveWorkRequest([FromBody] WorkRequestMetadataDTO wr)
        {
            return Repository.SaveWorkRequest(wr);
        }

        [HttpPost("approve")] // .../api/WorkRequests/approve
        [Authorize]
        [ScopeAuthorize("edit:ApproveDenyWorkRequests")]
        public WorkRequestMetadataDTO ApproveWorkRequest([FromBody] WorkRequestApprovalDTO wra)
        {
            Repository.ApproveWorkRequest(wra, User.getAuth0Id());
            return null;
        }

        [HttpPost("deny")] // .../api/WorkRequests/deny
        [Authorize]
        [ScopeAuthorize("edit:ApproveDenyWorkRequests")]
        public WorkRequestMetadataDTO DenyWorkRequest([FromBody] WorkRequestApprovalDTO wra)
        {
            Repository.DenyWorkRequest(wra, User.getAuth0Id());
            return null;
        }

        public WorkRequestUsedCountDTO GetCountsForWorkRequest([FromBody] Guid workRequestId)
        {
            Repository.GetCountsForWorkRequest(workRequestId);
        }

    }
}
