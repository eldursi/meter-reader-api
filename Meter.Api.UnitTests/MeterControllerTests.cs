using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Meter.Api.Controllers;
using Meter.Api.Helpers;
using Meter.Services;
using Meter.Services.Models;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Xunit;
using MeterReading = Meter.Api.Models.MeterReading;

namespace Meter.Api.UnitTests
{
    public class MeterControllerTests
    {
        [Theory]
        [AutoNSubstituteDataAttribute]
        public async Task GivenApiController_WhenIUploadCsvFile_ThenMessageIsReturned(
            List<MeterReading> apiModelReadings,
            List<IMeterReading> serviceModelReadings,
            [Frozen] IMeterService service,
            [Frozen] ICsvHelper csvHelper,
            IFormFile file,
            [Greedy] MeterController controller)
        {
            
            // Arrange
            csvHelper.GetMeterReading(file).ReturnsForAnyArgs(apiModelReadings);
            service.ProcessMeterReadings(serviceModelReadings).ReturnsForAnyArgs((successful: 10, unsuccessful: 2));
            
            // Act
            var result = await controller.Post(file);

            // Assert
            result.Should().Be("Valid rows in csv: 10 - Invalid rows in csv: 2");
        }
    }
}