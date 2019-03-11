using Castle.Windsor.Installer;
using MORM.IoC.Container;

namespace MORM.Apresentacao.IoC.Container
{
    public class AbstractAppContainer : AbstractContainer
    {
        private static AbstractAppContainer _abstractAppInstance;
        public static AbstractAppContainer AbstractAppInstance => _abstractAppInstance ?? (_abstractAppInstance = new AbstractAppContainer());

        protected override void Setup()
        {
            base.Setup();

            Install(FromAssembly.This());
        }
    }
}