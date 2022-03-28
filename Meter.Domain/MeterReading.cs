using System;

namespace Meter.Domain
{
    public class MeterReading
    {
        public MeterReading(int accountId, DateTime dateTime, int value)
        {
            AccountId = accountId;
            DateTime = dateTime;
            Value = value;
        }

        public int AccountId { get; }
        public DateTime DateTime { get; }
        public int Value { get; }
    }
}