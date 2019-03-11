using Castle.Windsor;

namespace MORM.IoC.Container
{
    public class AbstractContainer : WindsorContainer
    {
        private static AbstractContainer _abstractInstance;
        public static AbstractContainer AbstractInstance => _abstractInstance ?? (_abstractInstance = new AbstractContainer());

        public AbstractContainer()
        {
            Setup();
        }

        protected virtual void Setup()
        {
        }
    }
}