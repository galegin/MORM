using MORM.Aplicacao.Ioc.Installer;
using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Context;
using MORM.Repositorio.Dapper.Context;
using MORM.Repositorio.Interfaces;
using MORM.Repositorio.SqLite;
using MORM.Repositorio.Uow;

namespace MORM.Repositorio.Tests.Ioc.Installer
{
    public class BaseInstaller : AbstractInstaller
    {
        public override void InstallerAmbiente()
        {
            Register<IAmbiente, Ambiente>();
            Register<IEmpresa, Empresa>();
            Register<ITerminal, Terminal>();
            Register<IUsuario, Usuario>();
        }

        public override void InstallerConexao()
        {
            Register<IConnectionFactory, SqLiteHelper>();
        }

        public override void InstallerDataConext()
        {
            Register<IAbstractDataContext, AbstractDataContext>();
            Register<IAbstractDataContextDapper, AbstractDataContextDapper>();
        }

        public override void InstallerDomainServices()
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
            Register<IAbstractUnityOfWork, AbstractUnityOfWork>();
        }

        public override void InstallerViews()
        {
        }
    }
}