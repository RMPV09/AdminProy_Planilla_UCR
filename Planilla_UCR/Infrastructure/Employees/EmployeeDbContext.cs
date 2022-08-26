using Domain.Employees.Entities;
using Domain.People.Entities;
using Infrastructure.Core;
using Infrastructure.Employees.EntityMappings;
using Infrastructure.People.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Employees
{
    internal class EmployeeDbContext : ApplicationDbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options, ILogger<EmployeeDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeMap());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonMap());
        }
    }
}
