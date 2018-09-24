using System;

using CreditCard.Inspector.Services.Contracts;

namespace CreditCard.Inspector.Services.Services
{
    public class PingService : IPingService
    {
        public string GetValue()
        {
            return $@"Ping {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
        }
    }
}