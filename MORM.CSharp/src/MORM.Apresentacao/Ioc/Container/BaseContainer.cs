using Castle.Windsor.Installer;
using MORM.Aplicacao.Ioc.Container;

namespace MORM.Apresentacao.Ioc.Container
{
    public class BaseContainer : AbstractContainer
    {
        private static IAbstractContainer _instance;
        public static IAbstractContainer Instance =>
            _instance ?? (_instance = new BaseContainer());

        protected override void Setup()
        {
            base.Setup();   

            Install(FromAssembly.This());
        }
    }
} 