using MORM.IoC.Installer;

namespace MORM.Aplicacao.IoC.Installer
{
    public class AbstractApiRepositoryInstaller : AbstractRepositoryInstaller
    {
        protected override void Setup()
        {
            //Register<IAtendenteRepository, AtendenteRepository>();
        }
    }
}