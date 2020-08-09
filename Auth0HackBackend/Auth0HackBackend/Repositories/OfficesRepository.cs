using Auth0HackBackend.DTO;
using Auth0HackBackend.Model;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<SectionMetadataDTO> GetSectionMetadata()
        {
            return DbContext.Sections.Select(SectionMetadataDTO.MapToDTO);
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

        public WorkRequestUsedCountDTO GetCountsForWorkRequest(Guid workRequestId)
        {
            WorkRequestUsedCountDTO wrucDTO = new WorkRequestUsedCountDTO();
            wrucDTO.WorkRequestId = workRequestId;
            wrucDTO.SectionUsedCount = null;
            WorkRequest wr = DbContext.WorkRequests.Find(workRequestId);
            if (wr != null)
            {
                DateTimeOffset startTime = new DateTimeOffset(wr.StartTime.Year, wr.StartTime.Month, wr.StartTime.Day, 0, 0, 0, 0, wr.StartTime.Offset);
                DateTimeOffset endTime = startTime.AddDays(1);
                if (wr.SectionId != null)
                {
                    wrucDTO.SectionUsedCount = GetSectionCount(wr.SectionId.Value, wr.StartTime, startTime, endTime);
                }
                wrucDTO.OfficeUsedCount = GetOfficeCount(wr.OfficeId, wr.StartTime, startTime, endTime);
            }

            return wrucDTO;
        }

        private int GetSectionCount(Guid sectionId, DateTimeOffset workDate, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            return DbContext.WorkRequests.Count(
            x => x.SectionId == sectionId && x.ApprovalStatus.StatusName == "Approved" &&
                    ((x.StartTime >= startTime && x.EndTime <= endTime) ||
                    (x.EndTime >= startTime && x.EndTime <= endTime) ||
                    (startTime >= x.StartTime && startTime <= x.EndTime) ||
                    (endTime >= x.StartTime && endTime <= x.EndTime)));
        }

        private int GetOfficeCount(Guid officeId, DateTimeOffset workDate, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            return DbContext.WorkRequests.Count(
            x => x.OfficeId == officeId && x.ApprovalStatus.StatusName == "Approved" &&
                    ((x.StartTime >= startTime && x.EndTime <= endTime) ||
                    (x.EndTime >= startTime && x.EndTime <= endTime) ||
                    (startTime >= x.StartTime && startTime <= x.EndTime) ||
                    (endTime >= x.StartTime && endTime <= x.EndTime)));
        }
        public Task<SectionDetailDTO> GetSectionDetailsBySectionId(Section section, DateTimeOffset workDate, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            SectionDetailDTO secDetail = SectionDetailDTO.MapToDTOFunc(section);
            secDetail.SectionUsedCapacity = GetSectionCount(secDetail.SectionId, workDate, startTime, endTime);

            return Task.FromResult(secDetail);
        }
        public async Task<IEnumerable<SectionDetailDTO>> GetSectionDetailsByOfficeId(Guid officeId, DateTimeOffset workDate)
        {
            DateTimeOffset startTime = new DateTimeOffset(workDate.Year, workDate.Month, workDate.Day, 0, 0, 0, 0, workDate.Offset);
            DateTimeOffset endTime = startTime.AddDays(1);
            List<Section> sections = DbContext.Sections.Where(x => x.OfficeId == officeId).ToList();
            List<SectionDetailDTO> sectionDetails = new List<SectionDetailDTO>();
            foreach (Section section in sections)
            {                
                sectionDetails.Add(await GetSectionDetailsBySectionId(section, workDate, startTime, endTime));
            }

            return sectionDetails;
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

        public async Task<IQueryable<OfficeDetailDTO>> GetOfficeDetailsByDate(DateTimeOffset date)
        {
            var offices = DbContext.Offices.Include(x=>x.Sections).ToList();

            List<OfficeDetailDTO> dtos = new List<OfficeDetailDTO>();

            foreach (var office in offices)
            {
                var dto = OfficeDetailDTO.MapToDTOFunc(office);
                var capacities = DbContext.vOfficeDateCapacities.Where(x => x.StartTime == date && x.OfficeId == office.OfficeId);
                dto.OfficeUsedCapacity = capacities.Select(x => x.OfficeUsedCapacity).FirstOrDefault();
                foreach (var section in dto.Sections)
                {
                    section.SectionUsedCapacity = capacities.Where(x => x.SectionId == section.SectionId).Select(x => x.SectionUsedCapacity).FirstOrDefault();
                }
                dtos.Add(dto);
            }

            return dtos.AsQueryable();
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

        public OfficeMetadataDTO UpdateOrCreateOffice(OfficeMetadataDTO officeDTO)
        {
            Office newOffice = null;

            if (officeDTO.OfficeId != Guid.Empty)
            {
                newOffice = DbContext.Offices.Find(officeDTO.OfficeId);
            }
            if (newOffice != null) // Edit existing
            {
                newOffice.OfficeStreet = officeDTO.OfficeStreet;
                newOffice.OfficeCity = officeDTO.OfficeCity;
                newOffice.OfficeState = officeDTO.OfficeState;
                newOffice.OfficeZip = officeDTO.OfficeZip;
                newOffice.OfficeMaxCapacity = officeDTO.OfficeMaxCapacity;
                newOffice.OfficeSafeCapacity = officeDTO.OfficeSafeCapacity;                
            } else // Create new office
            {
                newOffice = OfficeMetadataDTO.MapToBaseFunc(officeDTO);
                newOffice.OfficeId = Guid.NewGuid();
                DbContext.Offices.Add(newOffice);
            }

            DbContext.SaveChanges();

            return OfficeMetadataDTO.MapToDTOFunc(newOffice);
        }

        public SectionMetadataDTO UpdateOrCreateSection(SectionMetadataDTO SectionDTO)
        {
            Section newSection = null;

            if (SectionDTO.SectionId != Guid.Empty)
            {
                newSection = DbContext.Sections.Find(SectionDTO.SectionId);
            }
            if (newSection != null) // Edit existing
            {
                newSection.OfficeId = SectionDTO.OfficeId;
                newSection.SectionDescription = SectionDTO.SectionDescription;
                newSection.SectionName = SectionDTO.SectionName;                
                newSection.SectionMaxCapacity = SectionDTO.SectionMaxCapacity;
                newSection.SectionSafeCapacity = SectionDTO.SectionSafeCapacity;
            }
            else // Create new Section
            {
                newSection = SectionMetadataDTO.MapToBaseFunc(SectionDTO);
                newSection.SectionId = Guid.NewGuid();
                DbContext.Sections.Add(newSection);
            }

            DbContext.SaveChanges();

            return SectionMetadataDTO.MapToDTOFunc(newSection);
        }
    }
}
