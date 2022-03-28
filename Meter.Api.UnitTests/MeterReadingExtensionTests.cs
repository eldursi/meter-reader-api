using AutoFixture.Xunit2;
using FluentAssertions;
using Meter.Api.Models;
using Xunit;

namespace Meter.Api.UnitTests
{
    public class MeterReadingExtensionTests
    {
        [Theory]
        [AutoData]
        public void ToApplicationMeterReading_MapMeterReading_ReturnsValidToApplicationMeterReading(MeterReading reading)
        {
            // Arrange
            
            // Act
            var result = reading.ToApplicationMeterReading();
            
            // Assert
            result.Value.Should().Be(reading.Value);
            result.AccountId.Should().Be(reading.AccountId);
            result.DateTime.Should().Be(reading.DateTime);
        } 
    }
}