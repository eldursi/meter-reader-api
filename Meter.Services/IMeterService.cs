using System.Collections.Generic;
using System.Threading.Tasks;
using Meter.Services.Models;

namespace Meter.Services
{
    public interface IMeterService
    {
        Task<(int successful, int unsuccessful)> ProcessMeterReadings(List<IMeterReading> readings);
    }
}