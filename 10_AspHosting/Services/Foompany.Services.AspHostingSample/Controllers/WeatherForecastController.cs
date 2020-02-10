using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Foompany.AspHostingSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Models.WeatherForecast> Get()
        {
            return new Models.WeatherForecast[]
            {
                new Models.WeatherForecast()
                {
                    Date = new DateTime(2020, 1, 20),
                    TemperatureC = 25,
                    Summary = "Warm",
                },
                new Models.WeatherForecast()
                {
                    Date = new DateTime(2020, 1, 21),
                    TemperatureC = 20,
                    Summary =  "Mild",
                },
                new Models.WeatherForecast()
                {
                    Date = new DateTime(2020, 1, 22),
                    TemperatureC = 5,
                    Summary =  "Chilly",
                },
            };
        }
    }
}
