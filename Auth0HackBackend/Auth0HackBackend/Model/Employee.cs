﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Model
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Auth0Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public bool isApprover { get; set; }
        public string Avatar { get; set; }
        public virtual ICollection<WorkRequest> Requests { get; set; }
        public virtual ICollection<WorkRequest> Approvals { get; set; }
        public virtual ICollection<WorkRequest> PersonalWorkRequests { get; set; }
    }
}
