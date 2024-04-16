using System;
using System.Linq;
using Phoesion.Glow.SDK;

namespace Foompany.Services.SampleService1.API.Modules
{
    public abstract class WeatherForecast
    {
        [Action(Methods.GET)]
        public static API.Dto.WeatherForecast[] GetForecast() => default;
    }
}
