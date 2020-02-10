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
