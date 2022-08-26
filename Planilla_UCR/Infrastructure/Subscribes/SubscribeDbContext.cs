using Domain.Subscribes.Entities;
using Domain.Subscriptions.Entities;
using Infrastructure.Core;
using Infrastructure.Subscribes.EntityMappings;
using Infrastructure.Subscriptions.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Subscribes
{
    public class SubscribeDbContext : ApplicationDbContext
    {
        public SubscribeDbContext(DbContextOptions<SubscribeDbContext> options, ILogger<SubscribeDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Subscribe> Subscribes { get; set; } = null!;
        public DbSet<Subscription> Subscriptions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SubscribeMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SubscriptionMap());
        }
    }
}
