using System;
using System.Threading.Tasks;


namespace Foompany.IncidentReport
{
    public interface IIncidentReporter
    {
        ValueTask<bool> AddReport(string sourceIP, string url, string message);
        ValueTask<bool> AddReport(string sourceIP, Uri url, string message);
        ValueTask<string> ReadReports();
    }
}
