using MORM.Ioc.Installer;

namespace MORM.Repositorio.Tests.Ioc.Installer
{
    public class RepositoryInstaller : AbstractRepositoryInstaller
    {
        protected override void Setup()
        {
            base.Setup();

            Register<ITipoRepository, TipoRepository>();
            Register<ITesteRepository, TesteRepository>();
        }
    }
}