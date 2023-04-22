using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Helpers
{
    /// <summary>
    /// A static logger to create one file for each session of execution
    /// Using a local logger per class create multiple files for the same tests
    /// 
    /// </summary>
    /// <Author>Med Kamal</Author>
    public static class LoggerHelper
    {
        private static Logger _log = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().WriteTo.File("logs/d_and_d.txt", rollingInterval: RollingInterval.Day).CreateLogger();

        public static Logger Log()
        {
            return _log;
        }
    }
}
