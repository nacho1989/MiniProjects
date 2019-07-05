using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace SignalRHubPOC.Castle_Windsor
{
    public class DependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;

        private readonly IDisposable _disposable;

        public DependencyScope(IWindsorContainer container)
        {
            _container = container;
            _disposable = container.BeginScope();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType).Cast<object>();
        }
    }
}