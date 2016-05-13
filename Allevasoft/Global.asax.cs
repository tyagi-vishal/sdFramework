using Allevasoft.Framework;
using Allevasoft.Services;
using Ninject;
using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace Allevasoft
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MiniProfilerEF6.Initialize();
            AreaRegistration.RegisterAllAreas(); 
            DependencyResolver.SetResolver(new IoCDependencyResolver());
            GlobalConfiguration.Configuration.DependencyResolver = DependencyResolver.Current.ToServiceResolver();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }
    }
}
