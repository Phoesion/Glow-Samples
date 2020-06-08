using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Foompany.Services.SampleService1
{
    /// <summary>
    /// This is the worker implementation.
    /// You can use BackgroundService class instead of IHostedService for a basic Start->Execute->Stop implementation
    /// </summary>
    class MyWorker : IHostedService
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
            logger.LogInformation("My worker started");

            //start worker logic in a separate task (and do not await it)
            _ = Task.Run(heartbeat);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            //stop worker
            logger.LogInformation("My worker is stopping");
            cancellationSource.Cancel();
            logger.LogInformation("My worker stopped");
        }

        async Task heartbeat()
        {
            var cancellationToken = cancellationSource.Token;
            while (!cancellationToken.IsCancellationRequested)
            {
                //count up
                Counter++;
                //print value
                logger.LogInformation($"Counter = {Counter}");
                //sleep a bit
                await Task.Delay(500, cancellationToken);
            }
        }
    }
}
