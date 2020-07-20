using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.SampleService1.ExternalEventConsumer
{
    /// <summary>
    /// This is a scoped service that will handle the incoming request
    /// </summary>
    class Handler
    {
        readonly IServiceProvider services;
        readonly ILogger logger;

        public Handler(IServiceProvider services, ILogger<Handler> logger)
        {
            this.services = services;
            this.logger = logger;
        }

        //emulate the handling of the incoming request
        public async Task HandleRequest(int req)
        {
            logger.LogInformation($"Handling request with id {req}");
        }
    }
}