using Meter.Infrastructure.DbContexts;
using Meter.Infrastructure.Repositories;

namespace Meter.Infrastructure
{
    public class Repository : IRepository
    {
        private AccountRepository _accountRepository;
        private readonly MeterReadingDbContext _context;
        private MeterReadingRepository _meterReadingsRepository;

        public Repository(MeterReadingDbContext context)
        {
            _context = context;
        }

        public IAccountRepository Accounts => _accountRepository ??= new AccountRepository(_context);

        public IMeterReadingRepository MeterReadings => _meterReadingsRepository ??= new MeterReadingRepository(_context);
    }
}