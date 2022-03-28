namespace Meter.Services.Models
{
    public interface IMeterReading
    {
        string AccountId { get; }
        string DateTime { get; }
        string Value { get; }
    }
}