using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssets.Configurations
{
    public class ActiveTypeConfiguration: IEntityTypeConfiguration<ActiveType>
    {
        public void Configure(EntityTypeBuilder<ActiveType> builder)
        {
            builder.ToTable("ActiveType");

            builder.HasKey(a => a.id);
        }
    }
}
