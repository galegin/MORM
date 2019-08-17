using MORM.Infra.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace MORM.Aplicacao.Resolver
{
    public class AbstractDependencyResolver : IDependencyResolver
    {
        private readonly IAbstractContainer _container;

        public AbstractDependencyResolver(IAbstractContainer container)
        {
            _container = container ?? throw new ArgumentNullException("container");
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

/*
internal sealed class WindsorDependencyResolver : IDependencyResolver
{
    private readonly IWindsorContainer _container;

    public WindsorDependencyResolver(IWindsorContainer container)
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
        return new WindsorDependencyScope(_container);
    }

    public void Dispose()
    {
    }
} 
*/
