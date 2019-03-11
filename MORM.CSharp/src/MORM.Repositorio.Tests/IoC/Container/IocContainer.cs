using Castle.Windsor.Installer;
using MORM.IoC.Container;

namespace MORM.Repositorio.Tests.IoC.Container
{
    public class IocContainer : AbstractContainer
    {
        private static IocContainer _instance;
        public static IocContainer Instance => _instance ?? (_instance = new IocContainer());

        protected override void Setup()
        {
            base.Setup();

            Install(FromAssembly.This());
        }
    }
}