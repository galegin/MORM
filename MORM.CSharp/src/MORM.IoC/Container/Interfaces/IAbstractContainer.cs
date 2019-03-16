using System;

namespace MORM.Ioc.Container
{
    public interface IAbstractContainer
    {
        T Resolve<T>();
        object Resolve(Type T);
    }
}