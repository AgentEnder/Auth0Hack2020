using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Auth0HackBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

namespace Auth0HackBackend.DTO
{
    public class EmployeeMetadataDTO
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public bool isApprover { get; set; }

        public static Expression<Func<Employee, EmployeeMetadataDTO>> MapToDTO = (v) =>
        new EmployeeMetadataDTO
        {
            EmployeeId = v.EmployeeId,
            FirstName = v.FirstName,
            LastName = v.LastName,
            Title = v.Title,
            isApprover = v.isApprover
        };

        public static Expression<Func<EmployeeMetadataDTO, Employee>> MapToBase = (v) =>
        new Employee
        {
            EmployeeId = v.EmployeeId,
            FirstName = v.FirstName,
            LastName = v.LastName,
            Title = v.Title,
            isApprover = v.isApprover
        };

        public static EmployeeMetadataDTO MapToDTOFunc(Employee e) {
            if (e == null)
            {
                return null;
            }
            return MapToDTO.Compile().Invoke(e);
        }

        public static Employee MapToBaseFunc(EmployeeMetadataDTO e)
        {
            return MapToBase.Compile().Invoke(e);
        }
    }
}
