﻿using Auth0HackBackend.DTO;
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

        public IQueryable<WorkRequestMetadataDTO> GetWorkRequestMetadata()
        {
            return DbContext.WorkRequests.Select(WorkRequestMetadataDTO.MapToDTO);
        }

        public async ValueTask<WorkRequestMetadataDTO> GetWorkRequestById(Guid WorkRequestId)
        {
            var workRequest = await DbContext.WorkRequests.FindAsync(WorkRequestId);
            return WorkRequestMetadataDTO.MapToDTOFunc(workRequest);
        }

        public IQueryable<WorkRequestMetadataDTO> GetWorkRequestsByEmployeeId(Guid EmployeeId)
        {
            return DbContext.WorkRequests.Where(x => x.PersonId == EmployeeId).Select(WorkRequestMetadataDTO.MapToDTO);
        }

        public WorkRequestMetadataDTO SaveWorkRequest(WorkRequestMetadataDTO wr)
        {
            WorkRequest newWR = WorkRequestMetadataDTO.MapToBaseFunc(wr);
            newWR.WorkRequestId = Guid.NewGuid();
            DbContext.WorkRequests.Add(newWR);
            DbContext.SaveChanges();

            return WorkRequestMetadataDTO.MapToDTOFunc(newWR);
        }
    }
}