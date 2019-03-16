using MORM.Ioc.Installer;

namespace MORM.Repositorio.Tests.Ioc.Installer
{
    public class AmbienteInstaller : AbstractAmbienteInstaller
    {
        protected override void Setup()
        {
            base.Setup();
            
            //Register<IUsuario, Usuario>();
            //Register<ITerminal, Terminal>();
        }
    }
}