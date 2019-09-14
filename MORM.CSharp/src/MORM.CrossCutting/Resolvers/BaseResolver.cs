using System;

namespace MORM.CrossCutting
{
    public abstract class BaseResolver : IBaseResolver
    {
        #region variaveis
        private IAbstractContainer _container => AbstractContainer.Instance;
        #endregion

        #region metodos
        public IRegisterClasse Register<IInstance, TInstance>()
            where IInstance : class
            where TInstance : class, IInstance
        {
            return _container.Register<IInstance, TInstance>();
        }

        public IInstance Resolve<IInstance>()
            where IInstance : class
        {
            return _container.Resolve<IInstance>();
        }

        public object Resolve(string nome)
        {
            return _container.Resolve(nome);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}