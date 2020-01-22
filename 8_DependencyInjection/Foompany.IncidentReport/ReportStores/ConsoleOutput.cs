using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Foompany.IncidentReport.ReportStores
{
    public class ConsoleOutput : IReportStore
    {
        public async ValueTask SaveReport(string entry)
        {
            Console.WriteLine("ConsoleOuput Report : " + entry);
        }

        public async ValueTask<string> ReadAllReports()
        {
            return null; //we don't save anything in this store, so return nothing..
        }
    }
}
