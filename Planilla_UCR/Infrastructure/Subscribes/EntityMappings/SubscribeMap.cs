using Domain.Subscribes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Subscribes.EntityMappings
{
    public class SubscribeMap : IEntityTypeConfiguration<Subscribe>
    {
        public void Configure(EntityTypeBuilder<Subscribe> builder)
        {
            builder.ToTable("Subscribes");

            builder.HasKey(p => new { p.EmployeeEmail, p.EmployerEmail, p.ProjectName, p.SubscriptionName, p.StartDate});

            builder.Property(p => p.Cost)
                 .IsRequired();

            builder.Property(p => p.EndDate);
        }
    }
}
