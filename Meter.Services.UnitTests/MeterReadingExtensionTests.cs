using System;
using FluentAssertions;
using Meter.Services.Models;
using Xunit;

namespace Meter.Services.UnitTests
{
    public class MeterReadingExtensionTests
    {
        [Fact]
        public void ToDomainMeterReading_MapMeterReading_ReturnsValidDomainMeterReadingObject()
        {
            // Arrange
            var reading = new MeterReading
            {
                AccountId = "1234",
                DateTime = DateTime.Now.ToString(),
                Value = "12345"
            };
            
            // Act
            var result = reading.ToDomainMeterReading();
            
            // Assert
            result.Value.ToString().Should().Be(reading.Value);
            result.AccountId.ToString().Should().Be(reading.AccountId);
            result.DateTime.ToString().Should().Be(reading.DateTime);
        } 
    }
}