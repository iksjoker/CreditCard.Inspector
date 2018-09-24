using System;
using NLog;

namespace CreditCard.Inspector.Core
{
    public class Log : ILog
    {
        private static Logger _logger;

        public Log()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        private static void WriteLog(CCLogLevel level, string message, Exception ex)
        {
            switch (level)
            {
                case CCLogLevel.Info:
                    _logger.Info(message);
                    break;
                case CCLogLevel.Warning:
                    _logger.Warn(message);
                    break;
                case CCLogLevel.Error:
                    _logger.Error(ex, message);
                    break;
                case CCLogLevel.Critical:
                    _logger.Fatal(ex, message);
                    break;
                default:
                    throw new CreditCardInspectorException("Unknown LogLevel state", new FormatException());
            }
        }

        public void Write(string message, Exception ex = null)
        {
            if (ex == null)
            {
                WriteLog(CCLogLevel.Info, message, null);
            }
            else
            {
                WriteLog(CCLogLevel.Error, $@"{message}. Error: {ex}", ex);
            }
        }

        public void Write(CCLogLevel level, string message, Exception ex = null)
        {
            WriteLog(CCLogLevel.Error, $@"{message}. Error: {ex}", ex);
        }
    }
}