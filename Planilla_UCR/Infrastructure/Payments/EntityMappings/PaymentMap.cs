using Domain.Payments.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Payments.EntityMappings
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");

            builder.HasKey(p => new { p.EmployeeEmail, p.EmployerEmail, p.ProjectName, p.StartDate, p.EndDate });
            builder.Property(p => p.GrossSalary);
        }
    }
}
