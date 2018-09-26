using CreditCard.Inspector.Services.Configuration;
using CreditCard.Inspector.Services.Contracts;
using NUnit.Framework;

namespace CreditCard.Inspector.Tests
{
    public class TestBase
    {
        protected static ICreditCardService CreditCardService 
            => EngineContext.Resolve<ICreditCardService>();

        protected TestBase()
        {
            NinjectConfig.Current.Init();
        }
    }
}