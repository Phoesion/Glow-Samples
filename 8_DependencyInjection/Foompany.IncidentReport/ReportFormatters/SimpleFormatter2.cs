using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Foompany.IncidentReport.ReportFormatters
{
    public class Formatter2 : IReportFormatter
    {
        public string FormatReport(string sourceIP, string url, string message)
        {
            return $"Time : {DateTime.UtcNow}, IP : {sourceIP}, Url : {url}, Message : {message}";
        }
    }
}
