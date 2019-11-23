using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foompany.Logger
{
    public static partial class Extensions
    {
        public static void AddLogger<TLogFormatter, TLogStore>(this IServiceCollection services)
            where TLogFormatter : class, ILogFormatter
            where TLogStore : class, ILogStore
        {
            //add a singleton of logger service 
            services.AddSingleton<ILogger, LoggerService>();

            //add the log formatter
            services.AddSingleton<ILogFormatter, TLogFormatter>();

            //add the log store
            services.AddSingleton<ILogStore, TLogStore>();
        }
    }
}
