using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Foompany.Logger
{
    // The implementation of ILogger
    class LoggerService : ILogger
    {
        readonly ILogFormatter Formatter;
        readonly ILogStore Store;

        public LoggerService(ILogFormatter Formatter, ILogStore Store)
        {
            this.Formatter = Formatter;
            this.Store = Store;
        }

        public async ValueTask<bool> AddLog(string sourceIP, string url)
        {
            try
            {
                //format log
                var str = Formatter.FormatLogEntry(sourceIP, url);

                //save log
                await Store.SaveLog(str);

                //done!
                return true;
            }
            catch { return false; }
        }

        public ValueTask<string> ReadLogs() => Store.ReadAllLogs();
    }
}
