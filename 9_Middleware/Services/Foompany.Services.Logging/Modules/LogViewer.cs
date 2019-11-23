using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.Logging.Modules
{
    /// <summary>
    /// This is the implementation of the firefly service module.
    /// It must implement all static methods specified in the api assembly
    /// </summary>
    [ModuleAPI(typeof(API.Logging.Modules.LogViewer))]
    public class LogViewer : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string Default()
        {
            return "Module up and running!";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody]
        public string GetLog()
        {
            //in a real scenario we would query the database, but in this sample we use a simple list..
            lock (Modules.Logger.Logs)
                return string.Join("\r\n", Modules.Logger.Logs);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
