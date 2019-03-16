using MORM.Ioc.Installer;

namespace MORM.Repositorio.Tests.Ioc.Installer
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