using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Subscriptions.Model
{
    public class SubscriptionModelMap : IEntityTypeConfiguration<SubscriptionModel>
    {
        public void Configure(EntityTypeBuilder<SubscriptionModel> builder)
        {
            builder.HasNoKey();

            builder.Property(p => p.SubscriptionName);

            builder.Property(p => p.SubscriptionDescription);

            builder.Property(p => p.Cost);

            builder.Property(p => p.TypeSubscription);

            builder.Property(p => p.IsEnabled);
        }
    }
}
