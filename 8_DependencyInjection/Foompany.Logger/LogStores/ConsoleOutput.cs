using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Foompany.Logger.LogStores
{
    public class ConsoleOutput : ILogStore
    {
        public static List<string> Logs = new List<string>();

        public async ValueTask SaveLog(string logentry)
        {
            Console.WriteLine("ConsoleOuput Logger : " + logentry);
        }

        public async ValueTask<string> ReadAllLogs()
        {
            return null; //we don't save anything in this store, so return nothing..
        }
    }
}
