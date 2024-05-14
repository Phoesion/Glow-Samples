using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK.Firefly.AspHost;
using Microsoft.AspNetCore.Builder;

namespace Foompany.Services.AspHostingMinimalSample
{
    [ServiceName("AspHostingMinimalSample")]
    public class ServiceMain : AspFireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        protected override void ConfigureWebApplication(GlowWebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapGet("/ping", (HttpContext httpContext) => "pong from minimal api!");

            app.MapGet("/weatherforecast",
                (HttpContext httpContext) =>
                {
                    return new WeatherForecast[]
                    {
                            new WeatherForecast()
                            {
                                Date = new DateOnly(2020, 1, 20),
                                TemperatureC = 25,
                                Summary = "Warm",
                            },
                            new WeatherForecast()
                            {
                                Date = new DateOnly(2020, 1, 21),
                                TemperatureC = 20,
                                Summary =  "Mild",
                            },
                            new WeatherForecast()
                            {
                                Date = new DateOnly(2020, 1, 22),
                                TemperatureC = 5,
                                Summary =  "Chilly",
                            },
                    };
                })
                .WithName("GetWeatherForecast")
                .WithOpenApi();

            app.Run();
        }
    }
}
