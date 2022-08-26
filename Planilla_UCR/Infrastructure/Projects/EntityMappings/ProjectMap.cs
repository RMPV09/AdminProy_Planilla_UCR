using Domain.Projects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Projects.EntityMappings
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");
            builder.HasKey(p => new { p.EmployerEmail, p.ProjectName });
            builder.Property(p => p.ProjectDescription);
            builder.Property(p => p.MaximumAmountForBenefits);
            builder.Property(p => p.MaximumBenefitAmount);
            builder.Property(p => p.PaymentInterval);
            builder.Property(p => p.IsEnabled);
            builder.Property(p => p.LastPaymentDate);
        }
    }
}
