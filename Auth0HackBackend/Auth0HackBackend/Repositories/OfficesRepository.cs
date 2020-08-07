using Auth0HackBackend.DTO;
using Auth0HackBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Repositories
{
    public class OfficesRepository
    {
        HackEntities DbContext { get; set; }

        public OfficesRepository(HackEntities entities)
        {
            DbContext = entities;
        }

        public IQueryable<OfficeMetadataDTO> GetOfficeMetadata()
        {
            return DbContext.Offices.Select(OfficeMetadataDTO.MapToDTO);
        }

        public async ValueTask<OfficeMetadataDTO> GetOfficeById(Guid officeId)
        {
            var office = await DbContext.Offices.FindAsync(officeId);
            return OfficeMetadataDTO.MapToDTOFunc(office);
        }
    }
}
