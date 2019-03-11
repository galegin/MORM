using MORM.IoC.Installer;

namespace MORM.Repositorio.Tests.IoC.Installer
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