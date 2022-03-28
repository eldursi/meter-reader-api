using Meter.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meter.Infrastructure.DbContexts.Configuration
{
    public class MeterReadingConfiguration : IEntityTypeConfiguration<MeterReading>
    {
        public void Configure(EntityTypeBuilder<MeterReading> builder)
        {
            builder
                .HasKey(a => a.Id);
            builder
                .Property(m => m.Id)
                .IsRequired();
            builder
                .Property(m => m.AccountId)
                .IsRequired();
            builder
                .Property(m => m.DateTime)
                .IsRequired();
            builder
                .Property(m => m.Updated)
                .IsRequired();
            builder
                .Property(m => m.Value)
                .IsRequired();

            builder
                .ToTable("MeterReadings");
        }
    }
}