using System;
using Ninject;

using CreditCard.Inspector.Core;

namespace CreditCard.Inspector.Services.Configuration
{
    public class EngineContext
    {
        public static T Resolve<T>()
        {
            var kernel = NinjectConfig.Current.Kernel;
            if (kernel == null)
                throw new CreditCardInspectorException("IoC container was not initialized", new ActivationException());

            var result = kernel.Get<T>();
            return result;
        }
    }
}