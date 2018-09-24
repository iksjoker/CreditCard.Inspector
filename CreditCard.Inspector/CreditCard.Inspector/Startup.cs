using System;
using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

using CreditCard.Inspector.Services.Configuration;

[assembly: OwinStartup(typeof(CreditCard.Inspector.Startup))]

namespace CreditCard.Inspector
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("default", "{controller}/{id}", new { id = RouteParameter.Optional });

            appBuilder
                .UseNinjectMiddleware(NinjectConfig.Current.Init)
                .UseNinjectWebApi(config);
        }
    }
}
