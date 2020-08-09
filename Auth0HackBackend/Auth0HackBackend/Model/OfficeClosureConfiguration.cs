using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0HackBackend.Model
{
    public class OfficeClosureConfiguration : IEntityTypeConfiguration<OfficeClosure>
    {
        public void Configure(EntityTypeBuilder<OfficeClosure> builder)
        {
            builder.HasKey(x => x.OfficeClosureId); // This one would be picked up by convention ({ClassnameId} would be autodetected, but this is a good example of configuring.            
        }
    }
}
