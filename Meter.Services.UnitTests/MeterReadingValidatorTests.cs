using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Meter.Infrastructure.Repositories;
using Meter.Services.Models;
using NSubstitute;
using Xunit;

namespace Meter.Services.UnitTests
{
    public class MeterReadingValidatorTests
    {
        [Fact]
        public async Task GetValidRecords_AllValidRecords_ReturnsAllSuccessfulRecords()
        {
            // Arrange
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
            var repository = Substitute.For<IRepository>();
            repository.Accounts.Exists(Arg.Any<int>()).ReturnsForAnyArgs(true);
            var validator = new MeterReadingValidator(repository);
            
            // Act
            var result = await validator.GetValidRecords(readings);
            
            // Assert
            result.Count.Should().Be(readings.Count);
        }
        
        [Fact]
        public async Task GetValidRecords_MeterReadingExists_ReturnsOnlyValidRecords()
        {
            // Arrange
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
            var repository = Substitute.For<IRepository>();
            repository.Accounts.Exists(Arg.Any<int>()).ReturnsForAnyArgs(true);
            repository.MeterReadings.Find(Arg.Any<Domain.MeterReading>()).Returns(new List<Domain.MeterReading>{readings.First().ToDomainMeterReading()});
            var validator = new MeterReadingValidator(repository);
            
            // Act
            var result = await validator.GetValidRecords(readings);
            
            // Assert
            result.Count.Should().Be(0);
        }
        
        [Fact]
        public async Task GetValidRecords_UserAccountDoesntExist_ReturnsOnlyValidRecords()
        {
            // Arrange
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
            var repository = Substitute.For<IRepository>();
            repository.Accounts.Exists(Arg.Any<int>()).ReturnsForAnyArgs(false);
            var validator = new MeterReadingValidator(repository);
            
            // Act
            var result = await validator.GetValidRecords(readings);
            
            // Assert
            result.Count.Should().Be(0);
        }
        
        [Fact]
        public async Task GetValidRecords_InValidReadingValueFormat_ReturnsOnlyValidRecords()
        {
            // Arrange
            var readings = new List<IMeterReading>{ 
                new MeterReading
                {
                    AccountId = "1234",
                    DateTime = DateTime.Now.ToString(),
                    Value = "Value"
                },
                new MeterReading{
                    AccountId = "5678",
                    DateTime = DateTime.Now.ToString(),
                    Value = "123"
                },
                new MeterReading{
                    AccountId = "9101",
                    DateTime = DateTime.Now.ToString(),
                    Value = "12345"
                },
            };
            var repository = Substitute.For<IRepository>();
            repository.Accounts.Exists(Arg.Any<int>()).ReturnsForAnyArgs(true);
            var validator = new MeterReadingValidator(repository);
            
            // Act
            var result = await validator.GetValidRecords(readings);
            
            // Assert
            result.Count.Should().Be(1);
        }
    }
}