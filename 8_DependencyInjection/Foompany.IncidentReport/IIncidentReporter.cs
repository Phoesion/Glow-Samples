using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Foompany.IncidentReport
{
    public interface IIncidentReporter
    {
        ValueTask<bool> AddReport(string sourceIP, string url, string message);
        ValueTask<string> ReadReports();
    }
}
