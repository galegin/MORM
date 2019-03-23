using MORM.Aplicacao.Ioc.Installer;
using MORM.Servico.Interfaces.nsAmbiente;
using MORM.Servico.Services.nsAmbiente;

namespace MORM.WebApi.Ioc
{
    public class ServiceInstaller : AbstractInstaller
    {
        public override void InstallerAmbiente()
        {
        }

        public override void InstallerCommands()
        {
        }

        public override void InstallerConexao()
        {
        }

        public override void InstallerDataConext()
        {
        }

        public override void InstallerDomainServices()
        {
        }

        public override void InstallerModels()
        {
        }

        public override void InstallerRepositories()
        {
        }

        public override void InstallerServices()
        {
            Register<IAmbienteService, AmbienteService>();
        }

        public override void InstallerUnitOfWork()
        {
        }

        public override void InstallerViewModels()
        {
        }

        public override void InstallerViews()
        {
        }
    }
}