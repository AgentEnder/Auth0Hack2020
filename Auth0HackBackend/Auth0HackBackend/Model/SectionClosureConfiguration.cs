using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Model
{
    public class SectionClosureConfiguration : IEntityTypeConfiguration<SectionClosure>
    {
        public void Configure(EntityTypeBuilder<SectionClosure> builder)
        {
            builder.HasKey(x => x.SectionClosureId); // This one would be picked up by convention ({ClassnameId} would be autodetected, but this is a good example of configuring.
        }
    }
}
