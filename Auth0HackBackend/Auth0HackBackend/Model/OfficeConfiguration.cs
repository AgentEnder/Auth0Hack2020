using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Model
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(x => x.OfficeId); // This one would be picked up by convention ({ClassnameId} would be autodetected, but this is a good example of configuring.
            builder.Property(x => x.OfficeLocation).HasColumnType("geography");
            builder.Property(x => x.OfficeState).HasMaxLength(2);
            builder.Property(x => x.OfficeZip).HasMaxLength(10);
            builder.Property(x => x.OfficeCity).HasMaxLength(60);
        }
    }
}
