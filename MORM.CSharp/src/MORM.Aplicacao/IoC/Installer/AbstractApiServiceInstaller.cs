using MORM.IoC.Installer;

namespace MORM.Aplicacao.IoC.Installer
{
    public class AbstractApiServiceInstaller : AbstractServiceInstaller
    {
        protected override void Setup()
        {
            //Register<IAtendenteService, AtendenteService>();
        }
    }
}