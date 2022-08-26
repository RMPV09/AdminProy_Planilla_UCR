using Domain.Agreements.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Agreements.EntityMappings
{
    internal class AgreementMap : IEntityTypeConfiguration<Agreement>
    {
        public void Configure(EntityTypeBuilder<Agreement> builder)
        {
            builder.ToTable("Agreement");
            builder.HasKey(p => new { p.EmployeeEmail, p.EmployerEmail, p.ProjectName, p.ContractStartDate });
            builder.Property(p => p.MountPerHour)
                 .IsRequired();
            builder.Property(p => p.ContractType)
                   .IsRequired();
            builder.Property(p => p.ContractFinishDate)
                    .IsRequired();
            builder.Property(p => p.IsEnabled)
                    .IsRequired();
            builder.Property(p => p.Justification)
                    .IsRequired();
        }
    }
}
