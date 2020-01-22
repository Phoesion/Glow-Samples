using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Foompany.IncidentReport.ReportFormatters
{
    public class JsonFormatter : IReportFormatter
    {
        public string FormatReport(string sourceIP, string url, string message)
        {
            return JsonConvert.SerializeObject(new { SourceIP = sourceIP, Url = url, Message = message });
        }
    }
}
