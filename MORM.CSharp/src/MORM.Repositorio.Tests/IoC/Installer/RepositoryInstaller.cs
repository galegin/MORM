using MORM.IoC.Installer;

namespace MORM.Repositorio.Tests.IoC.Installer
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