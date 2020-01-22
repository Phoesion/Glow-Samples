using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Foompany.IncidentReport.ReportFormatters
{
    public class SimpleFormatter : IReportFormatter
    {
        public string FormatReport(string sourceIP, string url, string message)
        {
            return $"[{sourceIP},{url}] : {message}";
        }
    }
}
