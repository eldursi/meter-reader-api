using System;
using Meter.Infrastructure.Models;

namespace Meter.Infrastructure
{
    public static class MeterReadingExtension
    {
        public static MeterReading ToInfrastructureMeterReading(this Domain.MeterReading reading)
        {
            return new MeterReading
            {
                Id = Guid.NewGuid(),
                Updated = DateTime.Now,
                AccountId = reading.AccountId,
                DateTime = reading.DateTime,
                Value = reading.Value
            };
        }

        public static Domain.MeterReading ToDomainMeterReading(this MeterReading reading)
        {
            return new Domain.MeterReading(reading.AccountId, reading.DateTime, reading.Value);
        }
    }
}