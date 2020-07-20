using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.SampleService1
{
    public static class ExternalEventConsumerExtensions
    {
        public static IServiceCollection RegisterExternalEventConsumer(this IServiceCollection services)
        {
            //add scoped handler service
            services.AddScoped<ExternalEventConsumer.Handler>();

            //add hosted service that will run in the background listening for incoming requests
            services.AddHostedService<ExternalEventConsumer.Worker>();

            return services;
        }
    }
}