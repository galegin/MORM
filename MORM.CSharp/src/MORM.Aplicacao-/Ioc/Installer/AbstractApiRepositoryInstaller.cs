using MORM.Ioc.Installer;

namespace MORM.Aplicacao.Ioc.Installer
{
    public class AbstractApiRepositoryInstaller : AbstractRepositoryInstaller
    {
        protected override void Setup()
        {
            //Register<IAtendenteRepository, AtendenteRepository>();
        }
    }
}