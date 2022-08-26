using Domain.Agreements.Entities;
using Infrastructure.Core;
using Infrastructure.Agreements.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Agreements
{
    internal class AgreementDbContext : ApplicationDbContext
    {
        public AgreementDbContext(DbContextOptions<AgreementDbContext> options, ILogger<AgreementDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Agreement> Agreements { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AgreementMap());
        }
    }
}
