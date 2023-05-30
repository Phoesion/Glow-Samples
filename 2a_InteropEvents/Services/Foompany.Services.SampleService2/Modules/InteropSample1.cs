using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Foompany.Services.SampleService2.Modules
{
    [API<API.SampleService1.Modules.SampleModule1.Events>]
    public class InteropSample1 : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [InteropBody]
        public string SomethingHappened(string someData)
        {
            logger.Information("Received event with data : " + someData);
            return $"SampleService2 received the event! (data='{someData}')";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
