using Meter.Services.Models;
using MeterReading = Meter.Api.Models.MeterReading;

namespace Meter.Api
{
    public static class MeterReadingExtension
    {
        public static IMeterReading ToApplicationMeterReading(this MeterReading reading)
        {
            return new Services.Models.MeterReading
            {
                AccountId = reading.AccountId, 
                DateTime = reading.DateTime, 
                Value = reading.Value
            };
        }
    }
}