using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

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

    public abstract class AbstractInstaller : IWindsorInstaller, IAbstractInstaller
    {
        private readonly AbstractInstallerTipo _tipo;

        public AbstractInstaller(AbstractInstallerTipo tipo)
        {
            _tipo = tipo;
        }

        public AbstractInstaller() : this(AbstractInstallerTipo.Singleton)
        {
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

        public abstract void InstallerAmbiente();
        public abstract void InstallerConexao();
        public abstract void InstallerDataConext();
        public abstract void InstallerDomainServices();
        public abstract void InstallerRepositories();
        public abstract void InstallerServices();
        public abstract void InstallerUnitOfWork();
        public abstract void InstallerViews();
        #endregion

        #region register
        private IWindsorContainer _container;
        private IConfigurationStore _store;

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _container = container;
            _store = store;
            Setup();
        }

        protected void Register<IObject, TObject>(AbstractInstallerTipo? tipo = null)
            where IObject : class
            where TObject : class, IObject
        {
            var registrationPar = Component.For<IObject, TObject>();
            var registration = registrationPar.GetRegister(tipo ?? _tipo);
            _container.Register(registration);
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
        public static IRegistration GetRegister<TObject>(this ComponentRegistration<TObject> registration, AbstractInstallerTipo tipo)
            where TObject : class
        {
            switch (tipo)
            {
                case AbstractInstallerTipo.Scope:
                    return registration.LifestyleScoped();
                case AbstractInstallerTipo.PerThread:
                    return registration.LifestylePerThread();
                case AbstractInstallerTipo.PerWebRequest:
                    return registration.LifestylePerWebRequest();
                case AbstractInstallerTipo.Singleton:
                    return registration.LifestyleSingleton();
                default:
                case AbstractInstallerTipo.Transient:
                    return registration.LifestyleTransient();
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