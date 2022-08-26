using Domain.ReportOfHours.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ReportOfHours.EntityMappings
{
    internal class HoursReportMap : IEntityTypeConfiguration<HoursReport>
    {
        public void Configure(EntityTypeBuilder<HoursReport> builder)
        {
            builder.ToTable("ReportOfHours");
            builder.HasKey(p => new { p.EmployerEmail, p.ProjectName, p.EmployeeEmail, p.ReportDate});
            builder.Property(p => p.ReportHours)
                .IsRequired();
            builder.Property(p => p.Approved);
                   
        }
    }
}
