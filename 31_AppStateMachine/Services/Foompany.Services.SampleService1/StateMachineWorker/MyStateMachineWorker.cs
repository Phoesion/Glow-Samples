using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using System.Threading;
using Foompany.Services.API.SampleService1;
using Foompany.Services.API.SampleService1.MyStateMachineStatesData;

namespace Foompany.Services.SampleService1
{
    sealed class MyStateMachineWorker : IAppStateMachineWorkerEx<MyStateMachineStates>
    {
        [Autowire]
        ILogger<MyStateMachineWorker> logger;


        // Use State Machine extended builder to setup handlers for state transitions
        // This is optional and is enabled using the IAppStateMachineWorkerEx interface.
        // When using the base IAppStateMachineWorker interface (without the Ex) only the default handler Run() will be used
        public void Build(IAppStateMachineBuilder<MyStateMachineStates> builder)
            => builder
                .Handle<InitializeDto>(MyStateMachineStates.Initialize,
                        async (ctx, data, ct) => { logger.LogInformation("In Initialize! with firstName {firstName} and lastName {lastName}", data?.FirstName, data?.LastName); })
                .Handle(MyStateMachineStates.State_B,
                        async (ctx, ct) => { logger.LogInformation("In StateB!"); })
                .Handle(MyStateMachineStates.State_B, MyStateMachineStates.State_A,
                        async (ctx, ct) => { logger.LogInformation("In StateB! (from State_A)"); });


        // Use default State-Transition handler
        public async Task Run(IAppStateMachineExecutionContext<MyStateMachineStates> context, MyStateMachineStates state, MyStateMachineStates fromState, CancellationToken cancellationToken)
        {
            //Do work here...

            //log something
            logger.Information("running state {state} (from state {oldState}), with data {@data}", state, fromState, context.GetData<object>());

            //throw unhandled exception to simulate error
            if (state == MyStateMachineStates.BadState)
                throw new Exception($"Failed in state {state}, for the {context.RunCount} time");

            //simulate work with delay.. (and status processing)
            if (state == MyStateMachineStates.State_A)
            {
                context.Status = "Starting sleep...";
                context.Progress = 10;
                await Task.Delay(3000, cancellationToken);
                context.Progress = 30;
                await Task.Delay(3000, cancellationToken);
                context.Progress = 70;
                await Task.Delay(3000, cancellationToken);
                context.Progress = 90;
                context.Status = "sleep completed";
            }

            //set some sample result
            if (state == MyStateMachineStates.Initialize || state == MyStateMachineStates.State_A)
                context.Result = new
                {
                    MyData = $"Some result data for state {state}"
                };
        }

    }
}
