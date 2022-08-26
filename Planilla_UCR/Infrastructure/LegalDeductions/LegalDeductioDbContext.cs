using Domain.LegalDeductions.Entities;
using Infrastructure.Core;
using Infrastructure.LegalDeductions.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.LegalDeductions
{
    public class LegalDeductionDbContext : ApplicationDbContext
    {
        public LegalDeductionDbContext(DbContextOptions<LegalDeductionDbContext> options, ILogger<LegalDeductionDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<LegalDeduction> LegalDeductions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LegalDeductionMap());
        }
    }
}
