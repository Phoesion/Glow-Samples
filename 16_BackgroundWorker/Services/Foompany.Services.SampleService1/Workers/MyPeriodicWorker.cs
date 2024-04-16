using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;

namespace Foompany.Services.SampleService1.Workers
{
    /// <summary>
    /// This is sample periodic worker implementation, that counts up every few seconds.
    /// </summary>
    sealed class MyPeriodicWorker : FireflyBackgroundPeriodicWorker
    {
        protected override TimeSpan? Period => TimeSpan.FromSeconds(1);

        public long Counter { get; private set; }

        public override async Task ExecuteAsync(IServiceProvider services, CancellationToken stoppingToken)
        {
            //count up
            Counter++;
            //print value
            logger.Information($"Counter = {Counter}");
        }
    }
}
