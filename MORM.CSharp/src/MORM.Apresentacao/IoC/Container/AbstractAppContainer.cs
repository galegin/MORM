using Castle.Windsor.Installer;
using MORM.Ioc.Container;

namespace MORM.Apresentacao.Ioc.Container
{
    public class AbstractAppContainer : AbstractContainer
    {
        private static IAbstractContainer _instance;
        public static IAbstractContainer Instance =>
            _instance ?? (_instance = new AbstractAppContainer());

        protected override void Setup()
        {
            base.Setup();   

            Install(FromAssembly.This());
        }
    }
} 