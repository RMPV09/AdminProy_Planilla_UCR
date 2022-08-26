using Domain.Subscriptions.Entities;
using Infrastructure.Core;
using Infrastructure.Subscriptions.EntityMappings;
using Infrastructure.Subscriptions.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Subscriptions
{
    public class SubscriptionDbContext : ApplicationDbContext
    {
        public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options, ILogger<SubscriptionDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Subscription> Subscriptions { get; set; } = null!;
        public DbSet<SubscriptionModel> SubscriptionsModel { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SubscriptionMap());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SubscriptionModelMap());
        }
    }
}
