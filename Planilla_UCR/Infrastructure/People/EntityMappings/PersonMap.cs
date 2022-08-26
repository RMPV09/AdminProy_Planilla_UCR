using Domain.People.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.People.EntityMappings
{
    internal class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(p => p.Email);

            builder.Property(p => p.Name)
                   .IsRequired();

            builder.Property(p => p.LastName1);

            builder.Property(p => p.LastName2);

            builder.Property(p => p.Ssn)
                 .IsRequired();

            builder.Property(p => p.BankAccount)
               .IsRequired();

            builder.Property(p => p.Adress);

            builder.Property(p => p.PhoneNumber);

            builder.Property(p => p.IsEnabled)
                   .IsRequired();
        }
    }
}
