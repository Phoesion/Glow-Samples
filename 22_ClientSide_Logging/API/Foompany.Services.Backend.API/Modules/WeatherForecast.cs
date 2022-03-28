using System;
using System.Linq;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.Backend.API.Modules
{
    public static class WeatherForecast
    {
        [Action(Methods.GET)]
        public static API.Dto.WeatherForecast GetTodayForecast() => default;

        [Action(Methods.GET)]
        public static API.Dto.WeatherForecast[] GetNextDaysForecast(int days) => default;
    }
}
