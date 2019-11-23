using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Logger
{
    public interface ILogStore
    {
        ValueTask SaveLog(string logentry);

        ValueTask<string> ReadAllLogs();
    }
}
