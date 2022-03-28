using Meter.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meter.Infrastructure.DbContexts.Configuration
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .Property(m => m.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("UserAccounts");
        }
    }
}