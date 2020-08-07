using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Model
{
    public class WorkRequestConfiguration : IEntityTypeConfiguration<WorkRequest>
    {
        public void Configure(EntityTypeBuilder<WorkRequest> builder)
        {
            builder.HasKey(x => x.SectionId); // This one would be picked up by convention ({ClassnameId} would be autodetected, but this is a good example of configuring.            
            
            builder.HasOne(x => x.Approver)
                .WithMany()
                .HasForeignKey(z => z.ApproverId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Requestor)
                .WithMany()
                .HasForeignKey(z => z.RequestorId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Person)
                .WithMany()
                .HasForeignKey(z => z.PersonId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
