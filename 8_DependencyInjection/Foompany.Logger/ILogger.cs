using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Foompany.Logger
{
    public interface ILogger
    {
        ValueTask<bool> AddLog(string sourceIP, string url);
        ValueTask<string> ReadLogs();
    }
}
