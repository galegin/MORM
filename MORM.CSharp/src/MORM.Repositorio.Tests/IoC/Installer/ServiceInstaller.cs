using MORM.IoC.Installer;

namespace MORM.Repositorio.Tests.IoC.Installer
{
    public class ServiceInstaller : AbstractServiceInstaller
    {
        protected override void Setup()
        {
            base.Setup();

            Register<ITipoService, TipoService>();
            Register<ITesteService, TesteService>();
        }
    }
}