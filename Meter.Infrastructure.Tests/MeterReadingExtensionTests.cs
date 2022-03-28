using AutoFixture.Xunit2;
using FluentAssertions;
using Meter.Infrastructure.Models;
using Xunit;

namespace Meter.Infrastructure.Tests
{
    public class MeterReadingExtensionTests
    {
        [Theory]
        [AutoData]
        public void ToDomainMeterReading_MapMeterReading_ReturnsValidDomainMeterReadingObject(MeterReading reading)
        {
            // Arrange
            
            
            // Act
            var result = reading.ToDomainMeterReading();
            
            // Assert
            result.Value.Should().Be(reading.Value);
            result.AccountId.Should().Be(reading.AccountId);
            result.DateTime.Should().Be(reading.DateTime);
        } 
        
        [Theory]
        [AutoData]
        public void ToInfrastructureMeterReading_MapMeterReading_ReturnsValidDomainMeterReadingObject(Domain.MeterReading reading)
        {
            // Arrange
            
            
            // Act
            var result = reading.ToInfrastructureMeterReading();
            
            // Assert
            result.Value.Should().Be(reading.Value);
            result.AccountId.Should().Be(reading.AccountId);
            result.DateTime.Should().Be(reading.DateTime);
        } 
    }
}