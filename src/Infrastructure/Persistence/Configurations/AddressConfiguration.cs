using SourcefulTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SourcefulTask.Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(t => t.Street)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(t => t.City)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(t => t.PostCode)
                .HasMaxLength(10);
        }
    }
}