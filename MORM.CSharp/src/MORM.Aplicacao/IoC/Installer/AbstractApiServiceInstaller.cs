using MORM.Ioc.Installer;

namespace MORM.Aplicacao.Ioc.Installer
{
    public class AbstractApiServiceInstaller : AbstractServiceInstaller
    {
        protected override void Setup()
        {
            //Register<IAtendenteService, AtendenteService>();
        }
    }
}