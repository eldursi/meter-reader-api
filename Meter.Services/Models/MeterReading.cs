namespace Meter.Services.Models
{
    public class MeterReading : IMeterReading
    {
        public string AccountId { get; set; }
        public string DateTime { get; set; }
        public string Value { get; set; }
    }
}