using System.Linq;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Meter.Infrastructure.DbContexts;
using Meter.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Meter.Infrastructure.Tests.Repositories
{
    public class MeterRepositoryTests
    {
        [Theory]
        [AutoData]
        public async Task Exists_MeterReadingExists_ReturnsMeterReading(Domain.MeterReading reading)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MeterReadingDbContext>()
                .UseInMemoryDatabase(databaseName: "MeterReadings").Options;
            
            await using (var context = new MeterReadingDbContext(options))
            {
                context.MeterReadings.Add(reading.ToInfrastructureMeterReading());
                context.SaveChanges();
            }

            await using (var context = new MeterReadingDbContext(options))
            {
                var repository = new MeterReadingRepository(context);
                
                // Act
                var result = await repository.Find(reading);
                
                // Assert
                result.Should().NotBeNull();
                result.Count.Should().Be(1);
                result.First().Value.Should().Be(reading.Value);
                result.First().AccountId.Should().Be(reading.AccountId);
                result.First().DateTime.Should().Be(reading.DateTime);
            }
        }
        
        [Theory]
        [AutoData]
        public async Task Find_MeterReadingDoesNotExist_ReturnsEmptyList(Domain.MeterReading meterReading1, Domain.MeterReading meterReading2)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MeterReadingDbContext>()
                .UseInMemoryDatabase(databaseName: "MeterReadings").Options;
            
            await using (var context = new MeterReadingDbContext(options))
            {
                context.MeterReadings.Add(meterReading1.ToInfrastructureMeterReading());
                context.SaveChanges();
            }
            
            await using (var context = new MeterReadingDbContext(options))
            {
                var repository = new MeterReadingRepository(context);
                
                // Act
                var result = await repository.Find(meterReading2);
                
                // Assert
                result.Should().NotBeNull();
                result.Should().BeEmpty();
            }
        }
        
        [Theory]
        [AutoData]
        public async Task Find_MeterReadingTableEmpty_ReturnsEmptyList(Domain.MeterReading reading)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MeterReadingDbContext>()
                .UseInMemoryDatabase(databaseName: "MeterReadings").Options;

            await using var context = new MeterReadingDbContext(options);
            var repository = new MeterReadingRepository(context);
                
            // Act
            var result = await repository.Find(reading);
                
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }
    }
}