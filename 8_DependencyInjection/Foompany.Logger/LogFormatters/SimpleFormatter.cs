﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Foompany.Logger.LogFormatters
{
    public class SimpleFormatter : ILogFormatter
    {
        public string FormatLogEntry(string sourceIP, string url)
        {
            return $"{sourceIP} -> {url}";
        }
    }
}