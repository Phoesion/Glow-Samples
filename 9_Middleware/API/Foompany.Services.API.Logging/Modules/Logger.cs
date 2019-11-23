using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;

namespace Foompany.Services.API.Logging.Modules
{
    [API]
    public abstract class Logger
    {
        [Interop]
        public static void SubmitLog(string sourceIP, string url) { }
    }
}
