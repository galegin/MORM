using MORM.Infra.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace MORM.Aplicacao.Resolver
{
    public class AbstractDependencyScope : IDependencyScope
    {
        private readonly IAbstractContainer _container;
        private readonly IDisposable _scope;

        public AbstractDependencyScope(IAbstractContainer container)
        {
            _container = container ?? throw new ArgumentNullException("container");
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

/*
internal sealed class WindsorDependencyScope : IDependencyScope
{
    private readonly IWindsorContainer _container;
    private readonly IDisposable _scope;

    public WindsorDependencyScope(IWindsorContainer container)
    {
        _container = container ?? throw new ArgumentNullException("container");
        _scope = container.BeginScope();
    }

    public object GetService(Type t)
    {
        return _container.Kernel.HasComponent(t) ? _container.Resolve(t) : null;
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
*/
