using System.Threading.Tasks;

namespace Foompany.IncidentReport
{
    public interface IReportStore
    {
        ValueTask SaveReport(string entry);

        ValueTask<string> ReadAllReports();
    }
}
