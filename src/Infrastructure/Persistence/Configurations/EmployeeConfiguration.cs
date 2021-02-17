using SourcefulTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SourcefulTask.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(t => t.FirstName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(t => t.Pesel)
                .HasMaxLength(11);
        }
    }
}