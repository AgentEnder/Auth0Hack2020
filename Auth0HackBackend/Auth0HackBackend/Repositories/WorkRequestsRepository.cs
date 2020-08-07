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

        public WorkRequestsRepository(HackEntities entities)
        {
            DbContext = entities;
        }

        public IQueryable<WorkRequestMetadataDTO> GetRequestMetadata()
        {
            return DbContext.WorkRequests.Select(WorkRequestMetadataDTO.MapToDTO);
        }

        public async ValueTask<WorkRequestMetadataDTO> GetRequestById(Guid WorkRequestId)
        {
            var workRequest = await DbContext.WorkRequests.FindAsync(WorkRequestId);
            return WorkRequestMetadataDTO.MapToDTOFunc(workRequest);
        }
    }
}
