using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
   [Serializable]
    public class LoggerService
    {
        private ILog _log;

        public LoggerService(ILog log)
        {
            _log = log;
        }

        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;

        public void Info(object logMEssage)
        {
            if(IsWarnEnabled)
            {
                _log.Info(logMEssage);
            }
        }
        public void Debug(object logMEssage)
        {
            if (IsDebugEnabled)
            {
                _log.Debug(logMEssage);
            }
        }
        public void Warn(object logMEssage)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(logMEssage);
            }
        }
        public void Fatal(object logMEssage)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(logMEssage);
            }
        }
        public void Error(object logMEssage)
        {
            if (IsErrorEnabled)
            {
                _log.Error(logMEssage);
            }
        }

    }
}
