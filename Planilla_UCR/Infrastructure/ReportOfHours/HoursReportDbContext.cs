using Domain.ReportOfHours.Entities;
using Infrastructure.Core;
using Infrastructure.ReportOfHours.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.ReportOfHours
{
    internal class HoursReportDbContext : ApplicationDbContext
    {
        public HoursReportDbContext(DbContextOptions<HoursReportDbContext> options,
                               ILogger<HoursReportDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<HoursReport> HoursReport { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new HoursReportMap());
        }
    }
}
