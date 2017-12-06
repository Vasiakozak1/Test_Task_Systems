using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Test_Task_Systems.DataAccess.Contexts;
using Test_Task_Systems.DataProviders;
namespace Test_Task_Systems
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            container.RegisterSingleton<IConnectionService, ConnectionService>();
            container.Register<IDbContextFactory<SystemADbContext>, SystemsDbContextFactory<SystemADbContext>>();
            container.Register<IDbContextFactory<SystemBDbContext>, SystemsDbContextFactory<SystemBDbContext>>();
            container.Register<IDbContextFactory<SystemCDbContext>, SystemsDbContextFactory<SystemCDbContext>>();
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorWebApiDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
