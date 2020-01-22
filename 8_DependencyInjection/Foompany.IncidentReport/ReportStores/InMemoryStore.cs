using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Foompany.IncidentReport.ReportStores
{
    public class InMemoryStore : IReportStore
    {
        public static List<string> Reports = new List<string>();

        public async ValueTask SaveReport(string entry)
        {
            lock (Reports)
                Reports.Add(entry);
        }

        public async ValueTask<string> ReadAllReports()
        {
            lock (Reports)
                return string.Join("\r\n", Reports);
        }
    }
}
