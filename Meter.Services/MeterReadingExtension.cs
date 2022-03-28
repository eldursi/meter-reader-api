using System;
using Meter.Services.Models;
using MeterReading = Meter.Domain.MeterReading;

namespace Meter.Services
{
    public static class MeterReadingExtension
    {
        public static MeterReading ToDomainMeterReading(this IMeterReading reading)
        {
            return new MeterReading(
                int.Parse(reading.AccountId),
                DateTime.Parse(reading.DateTime),
                int.Parse(reading.Value));
        }
    }
}