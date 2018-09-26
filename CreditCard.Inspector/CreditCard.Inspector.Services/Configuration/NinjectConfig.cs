using System;
using Ninject;
using System.Reflection;
using CreditCard.Inspector.Core;
using CreditCard.Inspector.Data;
using CreditCard.Inspector.Services.Contracts;
using CreditCard.Inspector.Services.Services;

namespace CreditCard.Inspector.Services.Configuration
{
    public sealed class NinjectConfig
    {
        private static Lazy<NinjectConfig> _lazyConfig = new Lazy<NinjectConfig>(() => new NinjectConfig());

        public static NinjectConfig Current => _lazyConfig.Value;

        internal IKernel Kernel { get; private set; }

        private NinjectConfig()
        { }

        public StandardKernel Init()
        {
            var result = new StandardKernel();
            result.Load(Assembly.GetExecutingAssembly());
            result.Bind<ILog>().To<Log>().InSingletonScope();
            result.Bind<IUnitOfWork>().To<UnitOfWork>();
            result.Bind<ICardTypeDetector>().To<CardTypeDetector>();
            result.Bind<ICardValidationService>().To<CardValidationService>();
            result.Bind<ICreditCardService>().To<CreditCardService>();
            result.Bind<IPingService>().To<PingService>();

            Kernel = result;
            return result;
        }
    }
}