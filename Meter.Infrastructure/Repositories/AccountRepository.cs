using System;
using System.Threading.Tasks;
using Meter.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Meter.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MeterReadingDbContext _context;

        public AccountRepository(MeterReadingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int id)
        {
            try
            {
                var userAccount = await _context.UserAccounts
                    .SingleOrDefaultAsync(a => a.Id == id);
                if (userAccount != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }
    }
}