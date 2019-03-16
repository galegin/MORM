using MORM.Ioc.Installer;

namespace MORM.Repositorio.Tests.Ioc.Installer
{
    public class UnityOfWorkInstaller : AbstractUnityOfWorkInstaller
    {
        protected override void Setup()
        {
            base.Setup();

            //Register<IAbstractUnityOfWork, AbstractUnityOfWork>();
        }
    }
}