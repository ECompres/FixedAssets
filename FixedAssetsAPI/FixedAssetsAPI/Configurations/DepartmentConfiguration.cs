using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configurations
{
    public class DepartmentConfiguration: IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(a => a.id);

            builder.HasMany(a => a.employees)
                   .WithOne(b => b.department)
                   .HasForeignKey(c => c.departmentId);
        }
    }
}
