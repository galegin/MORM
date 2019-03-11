using Castle.Windsor.Installer;
using MORM.IoC.Container;

namespace MORM.Aplicacao.IoC.Container
{
    public class AbstractApiContainer : AbstractContainer
    {
        private static AbstractApiContainer _abstractApiInstance;
        public static AbstractApiContainer AbstractApiInstance => _abstractApiInstance ?? (_abstractApiInstance = new AbstractApiContainer());

        protected override void Setup()
        {
            base.Setup();

            Install(FromAssembly.This());
        }
    }
}