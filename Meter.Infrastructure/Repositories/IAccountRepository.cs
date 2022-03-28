using System.Threading.Tasks;

namespace Meter.Infrastructure.Repositories
{
    public interface IAccountRepository
    {
        Task<bool> Exists(int id);
    }
}