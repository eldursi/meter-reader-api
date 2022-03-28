using Meter.Infrastructure.DbContexts.Configuration;
using Meter.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Meter.Infrastructure.DbContexts
{
    public class MeterReadingDbContext : DbContext
    {
        public MeterReadingDbContext(DbContextOptions<MeterReadingDbContext> options)
            : base(options)
        {
        }

        public DbSet<MeterReading> MeterReadings { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new MeterReadingConfiguration());

            builder
                .ApplyConfiguration(new UserAccountConfiguration());
        }
    }
}