using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace WebShop.Web
{
    public class WebApiDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer container;
        private readonly UnityDependencyResolver dependencyResolver;

        public WebApiDependencyResolver(IUnityContainer container, UnityDependencyResolver dependencyResolver)
        {
            this.container = container;
            this.dependencyResolver = dependencyResolver;
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return dependencyResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return dependencyResolver.GetServices(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new WebApiDependencyResolver(child, dependencyResolver);
        }
    }
}