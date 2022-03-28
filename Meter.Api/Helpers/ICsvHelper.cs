using System.Collections.Generic;
using Meter.Api.Models;
using Microsoft.AspNetCore.Http;

namespace Meter.Api.Helpers
{
    public interface ICsvHelper
    {
        IEnumerable<MeterReading> GetMeterReading(IFormFile meterReadingFile);
    }
}