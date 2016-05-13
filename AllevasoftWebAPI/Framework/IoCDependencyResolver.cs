using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Allevasoft.Services;

namespace AllevasoftWebAPI.Framework
{
    public class IoCDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            return ServiceLocator.Current.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return ServiceLocator.Current.GetAll(serviceType);
        }
    }
}