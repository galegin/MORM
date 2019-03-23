using Castle.Windsor;
//using Castle.Windsor.Installer;

namespace MORM.Aplicacao.Ioc.Container
{
    public abstract class AbstractContainer : WindsorContainer, IAbstractContainer
    {
        //private static IAbstractContainer _instance;
        //public static IAbstractContainer Instance => 
        //    _instance ?? (_instance =  new AbstractContainer());

        protected AbstractContainer()
        {
            Setup();
        }

        protected virtual void Setup()
        {
            //Install(FromAssembly.This());
        }
    }
}