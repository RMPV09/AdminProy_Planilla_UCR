using Domain.AgreementTypes.Entities;
using Infrastructure.Core;
using Infrastructure.AgreementTypes.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.AgreementTypes
{
    internal class AgreementTypeDbContext : ApplicationDbContext
    {
        public AgreementTypeDbContext(DbContextOptions<AgreementTypeDbContext> options, ILogger<AgreementTypeDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<AgreementType> AgreementTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AgreementTypeMap());
        }
    }
}
