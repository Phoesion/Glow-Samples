using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.SampleService1
{
    [ServiceName("SampleService1")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //Add Worker
            //Note: you can use the AddHostedService<T>() extension here, but then the 'MyWorker' instance cannot be injected to other classes
            services.AddSingletonHostedService<Workers.MyWorker>();

            //Add a sample worker that handles external incoming request in proper scope/context and generate rayIds for logger
            services.RegisterExternalEventConsumer();
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //TODO: Configure middleware..
        }
    }
}
