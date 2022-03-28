using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meter.Infrastructure.Repositories;
using Meter.Services.Models;

namespace Meter.Services
{
    public class MeterService : IMeterService
    {
        private readonly IRepository _repository;
        private readonly IMeterReadingValidator _validator;

        public MeterService(IRepository repository, IMeterReadingValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<(int successful, int unsuccessful)> ProcessMeterReadings(List<IMeterReading> readings)
        {
            var validMeterReadingRecords = await _validator.GetValidRecords(readings);

            if (validMeterReadingRecords.Any())
            {
                var result = await _repository.MeterReadings.Add(
                    validMeterReadingRecords.Select(
                        r => r.ToDomainMeterReading()
                    ).ToList()
                );
                
                return (successful: result,
                    unsuccessful: readings.Count - result);
            }
            
            return (successful: 0, unsuccessful: readings.Count);
        }
    }
}