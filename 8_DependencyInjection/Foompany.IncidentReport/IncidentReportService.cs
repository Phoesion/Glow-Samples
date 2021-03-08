using System;
using System.Threading.Tasks;


namespace Foompany.IncidentReport
{
    // The implementation of IIncidentReport
    class IncidentReportService : IIncidentReporter
    {
        readonly IReportFormatter Formatter;
        readonly IReportStore Store;

        public IncidentReportService(IReportFormatter Formatter, IReportStore Store)
        {
            this.Formatter = Formatter;
            this.Store = Store;
        }

        public ValueTask<bool> AddReport(string sourceIP, Uri url, string message)
            => AddReport(sourceIP, url.ToString(), message);

        public async ValueTask<bool> AddReport(string sourceIP, string url, string message)
        {
            try
            {
                //format log
                var str = Formatter.FormatReport(sourceIP, url, message);

                //save log
                await Store.SaveReport(str);

                //done!
                return true;
            }
            catch { return false; }
        }

        public ValueTask<string> ReadReports() => Store.ReadAllReports();
    }
}
