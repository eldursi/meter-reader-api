using System.Linq;
using System.Threading.Tasks;
using Meter.Api.Helpers;
using Meter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterController : Controller
    {
        private readonly IMeterService _service;
        private readonly ICsvHelper _csvHelper;

        public MeterController(IMeterService service, ICsvHelper csvHelper)
        {
            _service = service;
            _csvHelper = csvHelper;
        }
       
        [HttpGet]
        [Route("/meter")]
        public IActionResult Get()
        {
            return View("Index");
        }
        
        [HttpPost("/meter-reading-uploads")]
        [Consumes("text/csv")]
        public async Task<string> Post([FromForm] IFormFile meterReadingFile)
        {
            var meterReading = _csvHelper.GetMeterReading(meterReadingFile).ToList();
            var result = await _service.ProcessMeterReadings(
                meterReading.ToList().Select(r =>
                    r.ToApplicationMeterReading()
                ).ToList());
            
            return $"Valid / Successful rows in csv: {result.successful} - Invalid /Unsucessful rows in csv: {result.unsuccessful}";
        }
    }
}