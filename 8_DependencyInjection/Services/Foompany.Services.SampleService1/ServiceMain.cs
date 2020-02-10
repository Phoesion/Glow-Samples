using Foompany.IncidentReport;
using Foompany.IncidentReport.ReportFormatters;
using Foompany.IncidentReport.ReportStores;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;
using System.Threading.Tasks;


namespace Foompany.Services.SampleService1
{
    public class ServiceMain : FireflyService
    {
        protected override async Task ConfigureServices(IServiceCollection services)
        {
            await base.ConfigureServices(services);

            //Add incident report service
            //services.AddLogger<SimpleFormatter, ConsoleOutput>();   //simple formatter that outputs to console
            services.AddIncidentReporter<JsonFormatter, ConsoleOutput>();   //format as json and output to console
        }

    }
}
