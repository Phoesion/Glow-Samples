using System;
using System.Collections.Generic;
using System.Text;

namespace Foompany.Logger
{
    public interface ILogFormatter
    {
        string FormatLogEntry(string sourceIP, string url);
    }
}
