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

        public List<Section> GetSectionsByOfficeId(Guid officeId)
        {
            return DbContext.Sections.Where(x => x.OfficeId == officeId).ToList();
        }

        public Task<SectionDetailDTO> GetSectionDetailsBySectionId(Section section, DateTimeOffset workDate, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            SectionDetailDTO secDetail = SectionDetailDTO.MapToDTOFunc(section);
            secDetail.SectionUsedCapacity = DbContext.WorkRequests.Count(
            x => x.SectionId == section.SectionId && x.ApprovalStatus.StatusName == "Approved" &&
                    ((x.StartTime >= startTime && x.EndTime <= endTime) ||
                    (x.EndTime >= startTime && x.EndTime <= endTime) ||
                    (startTime >= x.StartTime && startTime <= x.EndTime) ||
                    (endTime >= x.StartTime && endTime <= x.EndTime)));

            return Task.FromResult(secDetail);
        }
        public async Task<IEnumerable<SectionDetailDTO>> GetSectionDetailsByOfficeId(Guid officeId, DateTimeOffset workDate)
        {
            DateTimeOffset startTime = new DateTimeOffset(workDate.Year, workDate.Month, workDate.Day, 0, 0, 0, 0, workDate.Offset);
            DateTimeOffset endTime = startTime.AddDays(1);
            List<Section> sections = DbContext.Sections.Where(x => x.OfficeId == officeId).ToList();
            List<Task<SectionDetailDTO>> sectionDetails = new List<Task<SectionDetailDTO>>();
            foreach (Section section in sections)
            {                
                sectionDetails.Add(GetSectionDetailsBySectionId(section, workDate, startTime, endTime));
            }

            return await Task.WhenAll<SectionDetailDTO>(sectionDetails);
        }

        public async Task<OfficeDetailDTO> GetOfficeDetailById(Guid officeId, DateTimeOffset workDate)
        {
            DateTimeOffset startTime = new DateTimeOffset(workDate.Year, workDate.Month, workDate.Day, 0, 0, 0, workDate.Offset);
            DateTimeOffset endTime = startTime.AddDays(1);
            var office = DbContext.Offices.Find(officeId);
            OfficeDetailDTO officeDetail = OfficeDetailDTO.MapToDTOFunc(office);
            officeDetail.OfficeUsedCapacity = DbContext.WorkRequests.Count(
                x => x.OfficeId == officeId && x.ApprovalStatus.StatusName == "Approved" &&
                        ((x.StartTime >= startTime && x.EndTime <= endTime) ||
                (x.EndTime >= startTime && x.EndTime <= endTime) ||
                (startTime >= x.StartTime && startTime <= x.EndTime) ||
                (endTime >= x.StartTime && endTime <= x.EndTime)));

            officeDetail.Sections = await GetSectionDetailsByOfficeId(officeId, workDate);
            officeDetail.SnapshotDate = workDate;
            

            return officeDetail;
        }      
        
        public OfficeClosureDTO CloseOffice(OfficeClosureDTO officeClosureDTO)
        {
            OfficeClosure oc = null;

            if (officeClosureDTO.OfficeClosureId != Guid.Empty)
            {
                oc = DbContext.OfficeClosures.Find(officeClosureDTO.OfficeClosureId);
            }
            if (oc != null)
            {
                oc.Description = officeClosureDTO.Description;
                oc.EndTime = officeClosureDTO.EndTime;
                oc.OfficeId = oc.OfficeId;
                oc.StartTime = oc.StartTime;
            }
            else 
            {
                oc = OfficeClosureDTO.MapToBaseFunc(officeClosureDTO);
                oc.OfficeClosureId = Guid.NewGuid();
                DbContext.OfficeClosures.Add(oc);                
            }
            DbContext.SaveChanges();

            return OfficeClosureDTO.MapToDTOFunc(oc);
        }

        public SectionClosureDTO CloseSection(SectionClosureDTO sectionClosureDTO)
        {
            SectionClosure sc = SectionClosureDTO.MapToBaseFunc(sectionClosureDTO);
            DbContext.SectionClosures.Add(sc);
            DbContext.SaveChanges();
            return SectionClosureDTO.MapToDTOFunc(sc);
        }

    }
}
