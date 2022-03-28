using System;

namespace Meter.Infrastructure.Models
{
    public class MeterReading
    {
        public Guid Id { get; set; }
        public DateTime Updated { get; set; }
        public int AccountId { get; set; }
        public DateTime DateTime { get; set; }
        public int Value { get; set; }
    }
}