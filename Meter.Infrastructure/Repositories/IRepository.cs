namespace Meter.Infrastructure.Repositories
{
    public interface IRepository
    {
        IAccountRepository Accounts { get; }
        IMeterReadingRepository MeterReadings { get; }
    }
}