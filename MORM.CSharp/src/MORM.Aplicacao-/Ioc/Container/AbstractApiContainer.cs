using Castle.Windsor.Installer;
using MORM.Ioc.Container;

namespace MORM.Aplicacao.Ioc.Container
{
    public class AbstractApiContainer : AbstractContainer
    {
        private static IAbstractContainer _instance;
        public static IAbstractContainer Instance =>
            _instance ?? (_instance = new AbstractApiContainer());

        protected override void Setup()
        {
            base.Setup();

            Install(FromAssembly.This());
        }
    }
}