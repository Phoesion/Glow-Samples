using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Linq;

namespace Foompany.Services.Backend.Modules
{
    [API<API.Modules.WeatherForecast>]
    public class WeatherForecast : FireflyModule
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [Action(Methods.GET)]
        public string Default() => "WeatherForecast module up and running";


        [ActionBody(Methods.GET)]
        public API.Dto.WeatherForecast GetTodayForecast()
        {
            return new API.Dto.WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = 22,
                Summary = Summaries[2],
            };
        }


        [ActionBody(Methods.GET)]
        public API.Dto.WeatherForecast[] GetNextDaysForecast(int days)
        {
            //only up to 10 days!
            if (days > 10)
                throw PhotonException.BadRequest;

            //generate data
            var rng = new Random();
            return Enumerable.Range(1, days)
                             .Select(index => new API.Dto.WeatherForecast
                             {
                                 Date = DateTime.Now.AddDays(index),
                                 TemperatureC = rng.Next(-20, 55),
                                 Summary = Summaries[rng.Next(Summaries.Length)]
                             })
                             .ToArray();
        }
    }
}
