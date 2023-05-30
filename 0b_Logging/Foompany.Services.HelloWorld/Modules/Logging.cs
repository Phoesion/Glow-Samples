using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;

namespace Foompany.Services.HelloWorld.Modules
{
    public class Logging : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => $"{nameof(Logging)} module up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

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

        [Action(Methods.GET)]
        public string LogWithContext(string username, string someValue)
        {
            logger.Information("User {user} said {text} ", username, someValue);
            return "done!";
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
    }
}
