using MORM.Aplicacao.Ioc.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace MORM.Api.Ioc
{
    public class AbstractDependencyResolver : IDependencyResolver
    {
        private readonly IAbstractContainer _container;

        public AbstractDependencyResolver(IAbstractContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            _container = container;
        }

        public object GetService(Type t)
        {
            return _container.Resolve(t);
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