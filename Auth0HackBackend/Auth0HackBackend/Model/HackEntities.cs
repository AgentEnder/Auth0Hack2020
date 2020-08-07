using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Model
{
    public class HackEntities: DbContext
    {
        // Constructor called by AddDbContext in startup.cs
        public HackEntities(DbContextOptions<HackEntities> options) : base(options)
        { }


        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Do configurations here.
            builder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
