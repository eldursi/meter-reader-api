using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Meter.Infrastructure.Repositories;
using Meter.Services.Models;
using NSubstitute;
using Xunit;

namespace Meter.Services.UnitTests
{
    public class MeterServiceUnitTests
    {
        [Fact]
        public async Task ProcessMeterReadings_ValidReadings_ReturnsAllSuccessfulRecords()
        {
            // Arrange
            var repository = Substitute.For<IRepository>();
            var validator = Substitute.For<IMeterReadingValidator>();
            var readings = new List<IMeterReading>{ 
                new MeterReading
                {
                    AccountId = "1234",
                    DateTime = DateTime.Now.ToString(),
                    Value = "98765"
                },
                new MeterReading{
                    AccountId = "5678",
                    DateTime = DateTime.Now.ToString(),
                    Value = "54321"
                },
                new MeterReading{
                    AccountId = "9101",
                    DateTime = DateTime.Now.ToString(),
                    Value = "12345"
                },
            };
            validator.GetValidRecords(readings).Returns(readings);
            repository.MeterReadings.Add(Arg.Any<List<Domain.MeterReading>>()).ReturnsForAnyArgs(readings.Count);
            var service = new MeterService(repository, validator);
            
            // Act
            var result = await service.ProcessMeterReadings(readings);
            
            // Assert
            await validator.Received(1).GetValidRecords(readings);
            await repository.MeterReadings.Received(1).Add(Arg.Any<List<Domain.MeterReading>>());
            result.Should().Be((readings.Count, 0));
        }
        
        [Fact]
        public async Task ProcessMeterReadings_InValidReadings_ReturnsAllUnSuccessfulRecords()
        {
            // Arrange
            var repository = Substitute.For<IRepository>();
            var validator = Substitute.For<IMeterReadingValidator>();
            var readings = new List<IMeterReading>{ 
                new MeterReading
                {
                    AccountId = "1234",
                    DateTime = DateTime.Now.ToString(),
                    Value = "98765"
                },
                new MeterReading{
                    AccountId = "5678",
                    DateTime = DateTime.Now.ToString(),
                    Value = "54321"
                },
                new MeterReading{
                    AccountId = "9101",
                    DateTime = DateTime.Now.ToString(),
                    Value = "12345"
                },
            };
            validator.GetValidRecords(readings).Returns(new List<IMeterReading>());
            repository.MeterReadings.Add(Arg.Any<List<Domain.MeterReading>>()).ReturnsForAnyArgs(readings.Count);
            var service = new MeterService(repository, validator);

            // Act
            var result = await service.ProcessMeterReadings(readings);
            
            // Assert
            await validator.Received(1).GetValidRecords(readings);
            await repository.MeterReadings.Received(0).Add(Arg.Any<List<Domain.MeterReading>>());
            result.Should().Be((0, readings.Count));
        }
    }
}