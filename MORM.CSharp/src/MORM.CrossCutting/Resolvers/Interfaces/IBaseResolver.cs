using System;

namespace MORM.CrossCutting
{
    public interface IBaseResolver : IDisposable
    {
        IRegisterClasse Register<IInstance, TInstance>()
            where IInstance : class
            where TInstance : class, IInstance;

        IInstance Resolve<IInstance>()
            where IInstance : class;

        object Resolve(string nome);
    }
}