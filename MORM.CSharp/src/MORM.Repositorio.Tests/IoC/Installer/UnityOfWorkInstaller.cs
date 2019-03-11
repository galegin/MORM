using MORM.IoC.Installer;

namespace MORM.Repositorio.Tests.IoC.Installer
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