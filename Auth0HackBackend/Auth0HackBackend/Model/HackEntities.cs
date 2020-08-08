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
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"my connection string",
                x => x.UseNetTopologySuite());
        }
        */

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<OfficeClosure> OfficeClosures { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionClosure> SectionClosures { get; set; }
        public DbSet<WorkRequest> WorkRequests { get; set; }
                

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Do configurations here.                     
            builder.ApplyConfiguration(new ApprovalStatusConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new OfficeConfiguration());                       
            builder.ApplyConfiguration(new OfficeClosureConfiguration());
            builder.ApplyConfiguration(new SectionConfiguration());
            builder.ApplyConfiguration(new SectionClosureConfiguration());
            builder.ApplyConfiguration(new WorkRequestConfiguration());
        }
    }
}
