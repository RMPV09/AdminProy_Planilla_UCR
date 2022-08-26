using Domain.LegalDeductions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.LegalDeductions.EntityMappings
{
    public class LegalDeductionMap : IEntityTypeConfiguration<LegalDeduction>
    {
        public void Configure(EntityTypeBuilder<LegalDeduction> builder)
        {
            builder.ToTable("LegalDeduction");

            builder.HasKey(p => new { p.DeductionName, p.Cost});
        }
    }
}
