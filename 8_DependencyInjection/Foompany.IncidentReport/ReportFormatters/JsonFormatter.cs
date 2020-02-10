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
