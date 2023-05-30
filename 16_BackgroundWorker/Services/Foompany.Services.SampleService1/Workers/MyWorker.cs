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
    /// This is the worker implementation.
    /// You can use BackgroundService class instead of IHostedService for a basic Start->Execute->Stop implementation
    /// </summary>
    sealed class MyWorker : IHostedService
    {
        readonly ILogger logger;
        readonly CancellationTokenSource cancellationSource = new CancellationTokenSource();

        public long Counter { get; private set; }

        public MyWorker(ILogger<MyWorker> _logger)
        {
            this.logger = _logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.Information("My worker started");

            //start worker logic in a separate task (and do not await it)
            _ = Task.Run(heartbeat);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            //stop worker
            logger.Information("My worker is stopping");
            try { cancellationSource.Cancel(); } catch { }
            logger.Information("My worker stopped");
        }

        async Task heartbeat()
        {
            var cancellationToken = cancellationSource.Token;
            while (!cancellationToken.IsCancellationRequested)
            {
                //count up
                Counter++;
                //print value
                logger.Information($"Counter = {Counter}");
                //sleep a bit
                await Task.Delay(1000, cancellationToken);
            }
        }
    }
}
