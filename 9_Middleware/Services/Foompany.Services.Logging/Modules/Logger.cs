using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.Logging.Modules
{
    [ModuleAPI(typeof(API.Logging.Modules.Logger))]
    public class Logger : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        /// <summary> Keep logs in-memory for sample (in real world the would be stored in a database) </summary>
        public static List<string> Logs = new List<string>();


        [InteropBody]
        public static void SubmitLog(string sourceIP, string url)
        {
            lock (Logs)
            {
                //keep up to 100 entries
                if (Logs.Count > 100)
                    Logs.RemoveAt(0);

                //add url and ip in the logs
                Logs.Add($"Time : {DateTime.UtcNow}, IP : {sourceIP}, Url : {url}");
            }
        }
    }
}
