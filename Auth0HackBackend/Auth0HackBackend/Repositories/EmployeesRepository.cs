using Auth0HackBackend.DTO;
using Auth0HackBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Repositories
{
    public class EmployeesRepository
    {
        HackEntities DbContext { get; set; }

        public EmployeesRepository(HackEntities entities)
        {
            DbContext = entities;
        }

        public EmployeeMetadataDTO GetEmployeeByAuthId(string auth0Id)
        {
            var employee = DbContext.Employees.FirstOrDefault(x => x.Auth0Id == auth0Id);
            return EmployeeMetadataDTO.MapToDTOFunc(employee);
        }

        public IQueryable<EmployeeMetadataDTO> GetEmployeeMetadata()
        {
            return DbContext.Employees.Select(EmployeeMetadataDTO.MapToDTO);
        }

        public async ValueTask<EmployeeMetadataDTO> GetEmployeeById(Guid employeeId)
        {
            var employee = await DbContext.Employees.FindAsync(employeeId);
            return EmployeeMetadataDTO.MapToDTOFunc(employee);
        }
    }
}
