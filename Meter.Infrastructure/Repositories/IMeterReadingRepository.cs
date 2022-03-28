using System.Collections.Generic;
using System.Threading.Tasks;
using Meter.Domain;

namespace Meter.Infrastructure.Repositories
{
    public interface IMeterReadingRepository
    {
        Task<int> Add(List<MeterReading> readings);
        Task<List<MeterReading>> Find(MeterReading reading);
    }
}