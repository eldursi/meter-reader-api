using CsvHelper.Configuration.Attributes;

namespace Meter.Api.Models
{
    public class MeterReading
    {
        [Name("AccountId")] public string AccountId { get; set; }

        [Name("MeterReadingDateTime")] public string DateTime { get; set; }

        [Name("MeterReadValue")] public string Value { get; set; }
    }
}