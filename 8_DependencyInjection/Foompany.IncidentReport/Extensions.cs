using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foompany.IncidentReport
{
    public static partial class Extensions
    {
        public static void AddIncidentReporter<TFormatter, TStore>(this IServiceCollection services)
            where TFormatter : class, IReportFormatter
            where TStore : class, IReportStore
        {
            //add a singleton of logger service 
            services.AddSingleton<IIncidentReporter, IncidentReportService>();

            //add the log formatter
            services.AddSingleton<IReportFormatter, TFormatter>();

            //add the log store
            services.AddSingleton<IReportStore, TStore>();
        }
    }
}
