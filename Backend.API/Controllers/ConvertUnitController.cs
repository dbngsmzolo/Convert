using Backend.Data.Enums;
using Backend.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ConvertUnitController : Controller
    {
        private readonly IConvertRateService _convertRateService;

        public ConvertUnitController(IConvertRateService convertRateService)
        {
            _convertRateService = convertRateService;
        }

        [HttpGet]
        [Route("Convert")]
        public async Task<IActionResult> Get(double amount, int unit)
        {
            if (unit > (int)Units.ImperialToMetric)
                return NotFound();

            string unitName = GetUnitName(unit);
           
            var conversionRate = await _convertRateService.GetAsync(unitName);

            if (conversionRate == null)
                return NotFound();
            if (unitName == Units.FahrenheitToCelsius.ToString())
                return Ok(_convertRateService.FahrenheitToCelsius(amount, conversionRate));

            return Ok(_convertRateService.ConvertUnits(amount, conversionRate));
        }

        private string GetUnitName(int unit)
        {
            string unitName;
            switch (unit)
            {
                case (int)Units.CelsiusToFahrenheit:
                    unitName = Units.CelsiusToFahrenheit.ToString();
                    break;
                case (int)Units.FahrenheitToCelsius:
                    unitName = Units.FahrenheitToCelsius.ToString();
                    break;
                case (int)Units.SecondsToMinutes:
                    unitName = Units.SecondsToMinutes.ToString();
                    break;
                case (int)Units.MinutesToSeconds:
                    unitName = Units.MinutesToSeconds.ToString();
                    break;
                case (int)Units.MetricToImperial:
                    unitName = Units.MetricToImperial.ToString();
                    break;
                default:
                    unitName = Units.ImperialToMetric.ToString();
                    break;
            }
            return unitName;
        }

    }
}
