using System;
using System.Collections.Generic;
using System.Text;

namespace Foompany.IncidentReport
{
    public interface IReportFormatter
    {
        string FormatReport(string sourceIP, string url, string message);
    }
}
