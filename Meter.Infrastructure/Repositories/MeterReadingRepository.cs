using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meter.Domain;
using Meter.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Meter.Infrastructure.Repositories
{
    public class MeterReadingRepository : IMeterReadingRepository
    {
        private readonly MeterReadingDbContext _context;

        public MeterReadingRepository(MeterReadingDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(List<MeterReading> readings)
        {
            try
            {
                var dbMeterReadings = readings.Select(
                    r => r.ToInfrastructureMeterReading()
                ).ToList();
                await _context.MeterReadings.AddRangeAsync(dbMeterReadings);
                await _context.SaveChangesAsync();
                return readings.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding meter reading to database");
                return 0;
            }
        }

        public async Task<List<MeterReading>> Find(MeterReading reading)
        {
            var dbMeterReading = reading.ToInfrastructureMeterReading();
            try
            {
                var result = await _context.MeterReadings
                    .Where(m =>
                        m.AccountId == dbMeterReading.AccountId &&
                        m.Value == dbMeterReading.Value &&
                        m.DateTime == dbMeterReading.DateTime)
                    .ToListAsync();
                
                return result.Select(
                    r => r.ToDomainMeterReading()
                ).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving meter reading from database");
                return new List<MeterReading>();
            }
        }
    }
}