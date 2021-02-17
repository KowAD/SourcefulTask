using SourcefulTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SourcefulTask.Infrastructure.Persistence.Configurations
{
    public class EmployeeContractConfiguration : IEntityTypeConfiguration<EmployeeContract>
    {
        public void Configure(EntityTypeBuilder<EmployeeContract> builder)
        {
            builder.Property(t => t.Number)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.ValidFrom)
                .IsRequired();

            builder.Property(t => t.ValidTo)
                .IsRequired();
        }
    }
}