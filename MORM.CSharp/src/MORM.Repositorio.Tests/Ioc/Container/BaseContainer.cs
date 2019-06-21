using MORM.Aplicacao.Ioc.Container;
using MORM.Aplicacao.Ioc.Installer;

namespace MORM.Repositorio.Tests.Ioc.Container
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