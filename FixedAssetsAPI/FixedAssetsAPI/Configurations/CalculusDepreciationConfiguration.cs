using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configurations
{
    public class CalculusDepreciationConfiguration : IEntityTypeConfiguration<CalculusDepreciation>
    {
        public void Configure(EntityTypeBuilder<CalculusDepreciation> builder)
        {
            builder.ToTable("CalculusDepreciation");

            builder.HasKey(a => a.id);

            builder.HasOne(a => a.fixedAsset)
                .WithOne(b => b.calculusDepreciation);
                
        }
    }
}
