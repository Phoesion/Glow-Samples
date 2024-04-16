using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Foompany.Services.HelloWorld.Modules
{
    public class Logging : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => $"{nameof(Logging)} module up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        // Test uri : http://localhost/HelloWorld/Logging/LogDebug
        // Test uri : http://localhost/HelloWorld/Logging/LogInformation
        // Test uri : http://localhost/HelloWorld/Logging/LogWarning

        [Action(Methods.GET)]
        public string LogDebug()
        {
            logger.Debug("This is a simple DEBUG message");
            return "done!";
        }

        [Action(Methods.GET)]
        public string LogInformation()
        {
            logger.Information("This is a simple INFORMATION message");
            return "done!";
        }

        [Action(Methods.GET)]
        public string LogWarning()
        {
            logger.Information("This is a simple WARNING message");
            return "done!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        // Test uri : http://localhost/HelloWorld/Logging/LogWithContext?username=john&someValue=test

        [Action(Methods.GET)]
        public string LogWithContext(string username, string someValue)
        {
            logger.Information("User {user} said {text} ", username, someValue);
            return "done!";
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------

        //test uri : http://localhost/HelloWorld/Logging/SayHello?Name=John&Age=21

        [Action(Methods.GET)]
        public string SayHello([FromQueryRoot] Dtos.SampleReq user)
        {
            //NOTE: using the @ symbol instruct logger to serialize the 'user' (using json)
            logger.Information("Got a hello request from {@user}", user);

            return $"Hello {user.Name}!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string LogException()
        {
            try
            {
                //throw some exception to be caught and logged
                throw new Exception("This is an exception", new Exception("Some inner exception"));
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception caught!");
            }
            return "done!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        // Test uri : http://localhost/HelloWorld/Logging/CreateScopedLog

        [Action(Methods.GET)]
        public string CreateScopedLog()
        {
            logger.Information("Entering CreateScopedLog()");

            //create a scope
            using (logger.BeginScope("Performing migrations on user {username}", "john"))
            {
                logger.Information("Log within the scope");
                logger.Information("Another log within the scope");

                //create a inner scope
                using (logger.BeginScope("Converting user files"))
                {
                    logger.Information("converting file 1");
                    logger.Information("converting file 2");
                    logger.Information("converting completed");
                }

                //create a inner scope
                using (logger.BeginScope("Converting user emails"))
                {
                    logger.Information("converting email 1");
                    logger.Information("converting email 2");
                    logger.Information("converting completed");
                }

                logger.Information("Another log within the first scope");
            }

            logger.Information("Finished CreateScopedLog()");
            return "done!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        // Sample endpoint to produce interesting tracing data.
        // You can examine the trace activity from Blaze (in ray log inspector)
        // Test uri : http://localhost/HelloWorld/Logging/TracingTest

        [Action(Methods.GET)]
        public async Task<string> TracingTest()
        {
            //add an event in the middle of some delays
            await Task.Delay(10);
            Context.AddTraceEvent("sleep middle", LogLevel.Error, new() { { "key", "value" }, { "key2", "value2" } });
            await Task.Delay(10);

            //use dotnet's diagnostics Activity (also used by OpenTelemtry)
            var activity = Activity.Current;
            if (activity != null)
            {
                //add event
                await Task.Delay(10);
                var tags = new ActivityTagsCollection();
                tags.Add("a.key", "a.value");
                activity.AddEvent(new ActivityEvent("main activity sleep middle", tags: tags));
                await Task.Delay(10);
            }

            //start new activity
            using (var activity2 = Context.StartTraceActivity("my test activity span"))
            {
                //add event
                await Task.Delay(10);
                var tags = new ActivityTagsCollection();
                tags.Add("activity2.key", "activity2.value");
                activity2.AddEvent(new ActivityEvent("activity2 sleep middle", tags: tags));
                await Task.Delay(10);
            }

            //start new overlapping activities
            using (var activity3 = Context.StartTraceActivity("test activity3 span"))
            {
                //add event in tags2
                await Task.Delay(10);
                var tags = new ActivityTagsCollection();
                tags.Add("activity3.key", "activity3.value");
                activity3.AddEvent(new ActivityEvent("activity3 sleep middle", tags: tags));
                await Task.Delay(10);

                //start new activity
                using (var activity4 = Context.StartTraceActivity("test activity3 span"))
                {
                    //add event in activity4
                    await Task.Delay(10);
                    activity4.AddEvent(new ActivityEvent("activity4 sleep middle"));
                    await Task.Delay(10);
                }
                await Task.Delay(10);
            }

            return "done";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
