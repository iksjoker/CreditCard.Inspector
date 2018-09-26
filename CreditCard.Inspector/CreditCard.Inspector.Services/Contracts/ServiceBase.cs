using System;
using Ninject;

using CreditCard.Inspector.Core;

namespace CreditCard.Inspector.Services.Contracts
{
    public abstract class ServiceBase
    {
        [Inject]
        public ILog Log { get; set; }
    }
}