using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Foompany.Logger.LogFormatters
{
    public class JsonLogFormatter : ILogFormatter
    {
        public string FormatLogEntry(string sourceIP, string url)
        {
            return JsonConvert.SerializeObject(new { SourceIP = sourceIP, Url = url });
        }
    }
}
