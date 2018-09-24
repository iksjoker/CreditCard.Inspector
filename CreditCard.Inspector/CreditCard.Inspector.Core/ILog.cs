using System;

namespace CreditCard.Inspector.Core
{
    public interface ILog
    {
        void Write(string message, Exception ex = null);
        void Write(CCLogLevel level, string message, Exception ex = null);
    }
}