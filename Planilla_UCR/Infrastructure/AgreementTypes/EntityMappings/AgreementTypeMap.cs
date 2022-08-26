using Domain.AgreementTypes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AgreementTypes.EntityMappings
{
    internal class AgreementTypeMap : IEntityTypeConfiguration<AgreementType>
    {
        public void Configure(EntityTypeBuilder<AgreementType> builder)
        {
            builder.ToTable("AgreementType");
            builder.HasKey(p => new { p.TypeAgreement, p.MountPerHour});
        }
    }
}
    