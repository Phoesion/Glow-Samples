using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Foompany.Logger.LogStores
{
    public class InMemoryStore : ILogStore
    {
        public static List<string> Logs = new List<string>();

        public async ValueTask SaveLog(string logentry)
        {
            lock (Logs)
                Logs.Add(logentry);
        }

        public async ValueTask<string> ReadAllLogs()
        {
            lock (Logs)
                return string.Join("\r\n", Logs);
        }
    }
}
