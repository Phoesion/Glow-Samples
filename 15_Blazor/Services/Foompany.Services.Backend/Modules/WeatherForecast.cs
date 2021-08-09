using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Linq;

namespace Foompany.Services.Backend.Modules
{
    public class WeatherForecast : FireflyModule
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [Action(Methods.GET)]
        public string Default() => "WeatherForecast module up and running";

        [Action(Methods.GET)]
        public API.Dto.WeatherForecast[] GetForecast()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new API.Dto.WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
