using System.Threading.Tasks;
using FluentAssertions;
using Meter.Infrastructure.DbContexts;
using Meter.Infrastructure.Models;
using Meter.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Meter.Infrastructure.Tests.Repositories
{
    public class AccountRepositoryTests
    {
        [Fact]
        public async Task Exists_UserAccountExists_ReturnsTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MeterReadingDbContext>()
                .UseInMemoryDatabase(databaseName: "MeterReadings").Options;
            await using (var context = new MeterReadingDbContext(options))
            {
                context.UserAccounts.Add(new UserAccount
                {
                    Id= 1,
                    FirstName= "Hiba",
                    LastName= "Eldursi"
                });
                context.SaveChanges();
            }

            await using (var context = new MeterReadingDbContext(options))
            {
                var repository = new AccountRepository(context);
                
                // Act
                var result = await repository.Exists(1);
                
                // Assert
                result.Should().BeTrue();
            }
        }
        
        [Fact]
        public async Task Exists_UserAccountDoesNotExist_ReturnsTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MeterReadingDbContext>()
                .UseInMemoryDatabase(databaseName: "MeterReadings").Options;
            await using (var context = new MeterReadingDbContext(options))
            {
                context.UserAccounts.Add(new UserAccount
                {
                    Id= 1,
                    FirstName= "Hiba",
                    LastName= "Eldursi"
                });
                context.SaveChanges();
            }

            await using (var context = new MeterReadingDbContext(options))
            {
                var repository = new AccountRepository(context);
                
                // Act
                var result = await repository.Exists(5);
                
                // Assert
                result.Should().BeFalse();
            }
        }
        
        [Fact]
        public async Task Exists_EmptyDatabase_ReturnsFalse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MeterReadingDbContext>()
                .UseInMemoryDatabase(databaseName: "MeterReadings").Options;
            
            await using (var context = new MeterReadingDbContext(options))
            {
                var repository = new AccountRepository(context);
                
                // Act
                var result = await repository.Exists(5);
                
                // Assert
                result.Should().BeFalse();
            }
        }
    }
}