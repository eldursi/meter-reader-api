using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Meter.Api.Models;
using Microsoft.AspNetCore.Http;

namespace Meter.Api.Helpers
{
    public class CsvHelper : ICsvHelper
    {
        public IEnumerable<MeterReading> GetMeterReading(IFormFile meterReadingFile)
        {
            try
            {
                using var reader = new StreamReader(meterReadingFile.OpenReadStream());
                using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                return csvReader.GetRecords<MeterReading>().ToList();
            }
            catch(Exception ex)
            {
                // todo: this should be replaced with an actual logger that logs the exception
                Console.WriteLine("Error reading from uploaded file");
                return new List<MeterReading>();
            }
        }
    }
}