using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;
using Phoesion.Glow.SDK;

namespace Foompany.Services.SampleService1.ExternalEventConsumer
{
    /// <summary>
    /// This is worker implementation emulates receiving external request. (eg. Listening to an external broker)
    /// We need to create a Service scope for the request to be handled as well as a Logging scope.
    /// </summary>
    class Worker : BackgroundService
    {
        readonly IServiceProvider services;
        readonly ILogger logger;

        public Worker(IServiceProvider services, ILogger<Worker> logger)
        {
            this.services = services;
            this.logger = logger;
        }

        // The ExecuteAsync() implements the consumer that handles the requests one at a time.
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //Get external request
                var req = await readRequest();

                //create a Service/Logging scope to handle request
                using (var scope = services.CreateScope())
                using (logger.CreateRayScope(out PhotonId photonId))
                {
                    //we can now get a Scoped service like so
                    var handler = scope.ServiceProvider.GetRequiredService<Handler>();

                    //handle request in the proper scope
                    await handler.HandleRequest(req);
                }
            }
        }

        // This method emulates receiving a request from the outside world.
        int cnt = 0;
        async Task<int> readRequest()
        {
            await Task.Delay(3000);
            return ++cnt;
        }
    }
}