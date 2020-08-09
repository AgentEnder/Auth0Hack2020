using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Model
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.EmployeeId); // This one would be picked up by convention ({ClassnameId} would be autodetected, but this is a good example of configuring.
            builder.Property(x => x.Title).HasMaxLength(60);
            builder.Property(x => x.FirstName).HasMaxLength(60);
            builder.Property(x => x.LastName).HasMaxLength(60);

            builder.HasMany(x => x.PersonalWorkRequests)
                .WithOne(y => y.Person)
                .HasForeignKey(z => z.PersonId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Approvals)
                .WithOne(y => y.Approver)
                .HasForeignKey(z => z.ApproverId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Requests)
                .WithOne(y => y.Requestor)
                .HasForeignKey(z => z.RequestorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
