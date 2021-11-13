using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configurations
{
    public class FixedAssetConfiguration : IEntityTypeConfiguration<FixedAsset>
    {
        public void Configure(EntityTypeBuilder<FixedAsset> builder)
        {
            builder.ToTable("FixedAsset");

            builder.HasKey(a => a.id);

            builder.HasOne(a => a.department)
                .WithOne(b => b.fixedAsset);

            builder.HasOne(a => a.activeType)
                .WithOne(b => b.fixedAsset);
        }
    }
}
