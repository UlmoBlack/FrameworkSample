using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FİleLogger : LoggerService
    {
        public FİleLogger() : base(LogManager.GetLogger("JsonFileLogger"))
        {
        }
    }
}
