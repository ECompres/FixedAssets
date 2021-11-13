using Configurations;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fixed_Assets.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActiveTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CalculusDepreciationConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new FixedAssetConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ActiveType> ActiveType { get; set; }
        public DbSet<CalculusDepreciation> CalculusDepreciation { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<FixedAsset> FixedAsset { get; set; }
    }
}
