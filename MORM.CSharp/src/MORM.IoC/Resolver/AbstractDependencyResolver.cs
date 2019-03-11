using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace MORM.IoC.Container
{
    public class AbstractDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public AbstractDependencyResolver(IWindsorContainer container)
        {
            _container = container ?? throw new ArgumentNullException("container");
        }

        public object GetService(Type t)
        {
            return _container.Kernel.HasComponent(t) ? _container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return _container.ResolveAll(t).Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope()
        {
            return new AbstractDependencyScope(_container);
        }

        public void Dispose()
        {
        }
    }
}