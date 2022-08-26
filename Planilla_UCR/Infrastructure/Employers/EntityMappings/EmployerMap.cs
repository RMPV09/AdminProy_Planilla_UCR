using Domain.Employers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Employers.EntityMappings
{
    internal class EmployerMap : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.ToTable("Employer");
            builder.HasKey(p => p.Email);
        }
    }
}
