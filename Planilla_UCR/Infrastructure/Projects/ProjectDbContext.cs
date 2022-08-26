using Domain.Projects.Entities;
using Infrastructure.Core;
using Infrastructure.Projects.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Projects
{
    public class ProjectDbContext : ApplicationDbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options, 
            ILogger<ProjectDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Project> Projects { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProjectMap());
        }
    }
}
