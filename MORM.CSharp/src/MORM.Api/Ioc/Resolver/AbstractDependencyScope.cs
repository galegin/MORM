using MORM.Aplicacao.Ioc.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace MORM.Api.Ioc
{
    public class AbstractDependencyScope : IDependencyScope
    {
        private readonly IAbstractContainer _container;
        private readonly IDisposable _scope;

        public AbstractDependencyScope(IAbstractContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            _container = container;
            _scope = container.BeginScope();
        }

        public object GetService(Type t)
        {
            return _container.Resolve(t);
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return _container.ResolveAll(t).Cast<object>().ToArray();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}