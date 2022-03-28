using System.Collections.Generic;
using System.Threading.Tasks;
using Meter.Services.Models;

namespace Meter.Services
{
    public interface IMeterReadingValidator
    {
        Task<List<IMeterReading>> GetValidRecords(List<IMeterReading> reading);
    }
}