using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RedarborTechnicalTest.Core.Entities;
using RedarborTechnicalTest.Infrastructure.Data.Configuration;
using System.Data;

namespace RedarborTechnicalTest.Infrastructure.Data
{
    public class ApplicationEmployeeDbContext:DbContext
    {
        public ApplicationEmployeeDbContext(
        DbContextOptions<ApplicationEmployeeDbContext> options) : base(options)
        {
        }
        public virtual DbSet<EmployeeEntity> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelConfig(modelBuilder);
        }
        private void ModelConfig(ModelBuilder modelBuilder)
                  =>  new EmployeeConfiguration(modelBuilder.Entity<EmployeeEntity>());

    }
}
