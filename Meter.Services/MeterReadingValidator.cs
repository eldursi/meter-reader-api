using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Meter.Infrastructure.Repositories;
using Meter.Services.Models;

namespace Meter.Services
{
    public class MeterReadingValidator : IMeterReadingValidator
    {
        private readonly IRepository _repository;

        public MeterReadingValidator(IRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<IMeterReading>> GetValidRecords(List<IMeterReading> readings)
        {
            var validRecords = new List<IMeterReading>();
            foreach (var reading in readings)
            {
                if (await IsValid(reading))
                {
                    validRecords.Add(reading);
                }
            }

            return validRecords;
        }

        private async Task<bool> IsValid(IMeterReading r)
        {
            return ReadingValueFormatIsValid(r) && !(await MeterReadingExists(r)) && await AccountIdIsValid(r);
        }

        private async Task<bool> MeterReadingExists(IMeterReading reading)
        {
            var entry = await _repository.MeterReadings.Find(reading.ToDomainMeterReading());
            if (entry != null && entry.Any()) return true;
            
            return false;
        }

        private async Task<bool> AccountIdIsValid(IMeterReading reading)
        {
            // check the database and check the accountid value isn't null

            return reading.AccountId != null && 
                   int.TryParse(reading.AccountId, out int accountId) &&
                   await _repository.Accounts.Exists(accountId);
        }

        private bool ReadingValueFormatIsValid(IMeterReading reading)
        {
            var rgx = new Regex(@"\b\d{5}\b");
            return rgx.IsMatch(reading.Value);
        }
    }
}