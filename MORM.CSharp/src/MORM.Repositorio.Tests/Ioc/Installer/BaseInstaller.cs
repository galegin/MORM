using MORM.Aplicacao.Ioc.Installer;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Dapper.Context;
using MORM.Repositorio.SqLite;

namespace MORM.Repositorio.Tests.Ioc.Installer
{
    public class BaseInstaller : AbstractInstaller
    {
        public override void InstallerAmbiente()
        {
            //Register<IUsuario, Usuario>();
            //Register<ITerminal, Terminal>();
        }

        public override void InstallerCommands()
        {
        }

        public override void InstallerConexao()
        {
            Register<IConnectionFactory, SqLiteHelper>();
        }

        public override void InstallerDataConext()
        {
            Register<IAbstractDataContextDapper, AbstractDataContextDapper>();
        }

        public override void InstallerDomainServices()
        {
        }

        public override void InstallerModels()
        {
        }

        public override void InstallerRepositories()
        {
            Register<ITipoRepository, TipoRepository>();
            Register<ITesteRepository, TesteRepository>();
        }

        public override void InstallerServices()
        {
            Register<ITipoService, TipoService>();
            Register<ITesteService, TesteService>();
        }

        public override void InstallerUnitOfWork()
        {
            //Register<IAbstractUnityOfWork, AbstractUnityOfWork>();
        }

        public override void InstallerViewModels()
        {
        }

        public override void InstallerViews()
        {
        }
    }
}