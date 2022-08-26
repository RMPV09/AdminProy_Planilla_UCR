using Domain.Payments.Entities;
using Infrastructure.Core;
using Infrastructure.Payments.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Payments
{
    public class PaymentDbContext : ApplicationDbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options, ILogger<PaymentDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Payment> Payments { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PaymentMap());
        }
    }
}
