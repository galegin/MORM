using MORM.Aplicacao.Ioc.Container;

namespace MORM.Aplicacao.Ioc.Installer
{
    public enum AbstractInstallerTipo
    {
        PerThread,
        PerWebRequest,
        Scope,
        Singleton,
        Transient,
    }

    public abstract class AbstractInstaller : IAbstractInstaller
    {
        private readonly AbstractInstallerTipo _tipo;

        public AbstractInstaller() : this(AbstractInstallerTipo.Singleton)
        {
        }

        public AbstractInstaller(AbstractInstallerTipo tipo)
        {
            _tipo = tipo;
        }

        #region installer
        protected virtual void Setup()
        {
            InstallerAmbiente();
            InstallerConexao();
            InstallerDataConext();
            InstallerDomainServices();
            InstallerRepositories();
            InstallerServices();
            InstallerUnitOfWork();
            InstallerViews();
        }

        public virtual void InstallerAmbiente() { }
        public virtual void InstallerConexao() { }
        public virtual void InstallerDataConext() { }
        public virtual void InstallerDomainServices() { }
        public virtual void InstallerRepositories() { }
        public virtual void InstallerServices() { }
        public virtual void InstallerUnitOfWork() { }
        public virtual void InstallerViews() { }
        #endregion

        #region register
        private IAbstractContainer _container;

        public virtual void Install(IAbstractContainer container)
        {
            _container = container;
            Setup();
        }

        protected void Register<IObject, TObject>(AbstractInstallerTipo? tipo = null)
            where IObject : class
            where TObject : class, IObject
        {
            var registration = (tipo ?? _tipo);
            var registerTipo = registration.GetRegisterTipo();
            _container.Register<IObject, TObject>(registerTipo);
        }

        protected void RegisterScope<IObject, TObject>()
            where IObject : class
            where TObject : class, IObject
        {
            Register<IObject, TObject>(AbstractInstallerTipo.Scope);
        }

        protected void RegisterSingleton<IObject, TObject>()
            where IObject : class
            where TObject : class, IObject
        {
            Register<IObject, TObject>(AbstractInstallerTipo.Singleton);
        }

        protected void RegisterTransient<IObject, TObject>()
            where IObject : class
            where TObject : class, IObject
        {
            Register<IObject, TObject>(AbstractInstallerTipo.Transient);
        }
        #endregion
    }

    #region extension
    public static class ComponentRegistrationExtension
    {
        public static RegisterTipo GetRegisterTipo(this AbstractInstallerTipo tipo)
        {
            switch (tipo)
            {
                case AbstractInstallerTipo.Scope:
                    return RegisterTipo.Scope;
                case AbstractInstallerTipo.PerThread:
                    return RegisterTipo.PerThread;
                case AbstractInstallerTipo.PerWebRequest:
                    return RegisterTipo.PerWebRequest;
                case AbstractInstallerTipo.Singleton:
                    return RegisterTipo.Singleton;
                default:
                case AbstractInstallerTipo.Transient:
                    return RegisterTipo.Transient;
            }
        }
    }
    #endregion
}

/*
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web;
using VirtualWebService.Repository;
using VirtualWebService.RepositoryInterfaces;
using VirtualWebService.Utils;

namespace VirtualWebService.Ioc.Installers
{
    public class UnitOfWorkInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWorkConsulta>().UsingFactoryMethod(GetUoWConsulta).LifestylePerWebRequest());
            container.Register(Component.For<IUnitOfWorkGravacao>().UsingFactoryMethod(GetUoWGravacao).LifestylePerWebRequest());
        }

        private UnitOfWorkConsulta GetUoWConsulta()
        {
            var credencial = HeaderCredenciais.GetFromRequest();
            return new UnitOfWorkConsulta(credencial.Usuario, credencial.Senha);
        }

        private UnitOfWorkGravacao GetUoWGravacao()
        {
            var credencial = HeaderCredenciais.GetFromRequest();
            return new UnitOfWorkGravacao(credencial.Usuario, credencial.Senha);
        }
    }
} 
*/