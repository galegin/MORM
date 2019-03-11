using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MORM.IoC.Installer
{
    public enum AbstractInstallerTipo
    {
        PerThread,
        PerWebRequest,
        Scope,
        Singleton,
        Transient,
    }

    public class AbstractInstaller : IWindsorInstaller
    {
        private readonly AbstractInstallerTipo _tipo;

        public AbstractInstaller(AbstractInstallerTipo tipo)
        {
            _tipo = tipo;
        }

        public AbstractInstaller() : this(AbstractInstallerTipo.Singleton)
        {
        }

        private IWindsorContainer _container;
        private IConfigurationStore _store;

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _container = container;
            _store = store;
            Setup();
        }

        protected virtual void Setup()
        {
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
    }

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
}