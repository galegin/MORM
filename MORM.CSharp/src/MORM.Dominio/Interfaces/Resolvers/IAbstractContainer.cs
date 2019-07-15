using System;
using System.Collections.Generic;

namespace MORM.Dominio.Interfaces
{
    public enum RegisterTipo
    {
        PerThread,
        PerWebRequest,
        Scope,
        Singleton,
        Transient,
    }

    public interface IAbstractContainer : IDisposable
    {
        void Register<IObject, TObject>(RegisterTipo tipo = RegisterTipo.Transient) where IObject : class
            where TObject : class, IObject;
        void RegisterScope<IObject, TObject>() where IObject : class
            where TObject : class, IObject;
        void RegisterSingleton<IObject, TObject>() where IObject : class
            where TObject : class, IObject;
        void RegisterTransient<IObject, TObject>() where IObject : class
            where TObject : class, IObject;

        void RegisterAll(Type[] types);

        IObject Resolve<IObject>() where IObject : class;

        object Resolve(Type type);

        IEnumerable<object> ResolveAll(Type type);

        IAbstractContainer BeginScope();
    }
}