using Castle.Windsor.Installer;
using MORM.Ioc.Container;

namespace MORM.Repositorio.Tests.Ioc.Container
{
    public class AbstractIocContainer : AbstractContainer
    {
        private static IAbstractContainer _instance;
        public static IAbstractContainer Instance =>
            _instance ?? (_instance = new AbstractIocContainer());

        protected override void Setup()
        {
            base.Setup();

            Install(FromAssembly.This());
        }
    }
}