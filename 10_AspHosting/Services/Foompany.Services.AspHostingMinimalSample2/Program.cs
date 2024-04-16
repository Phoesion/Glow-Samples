using Foompany.Services.AspHostingMinimalSample2;

//specify Glow service name
[assembly: ServiceName("AspHostingMinimalSample2")]

//----------------------------------
// Configure application builder
//----------------------------------
var builder = GlowWebApplicationBuilder.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add auth services
services.AddAuthentication();
services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

//----------------------------------
// Build application
//----------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

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

//----------------------------------
// Run application
//----------------------------------
app.Run();
