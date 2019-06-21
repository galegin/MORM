using MORM.Aplicacao.Ioc.Installer;
using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Mocks;
using MORM.Repositorio.Dapper.Context;
using MORM.Repositorio.Interfaces;
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

        public override void InstallerDataConext()
        {
            Register<IAbstractDataContext, MockDataContext>();
            Register<IAbstractDataContextDapper, AbstractDataContextDapper>();
        }

        public override void InstallerRepositories()
        {
            Register<ITipoRepository, TipoRepository>();
            Register<ITesteRepository, TesteRepository>();
        }

        public override void InstallerServices()
        {
            Register<IReferenciaService, ReferenciaService>();
            Register<ITesteService, TesteService>();
            Register<ITipoService, TipoService>();
        }

        public override void InstallerUnitOfWork()
        {
            Register<IAbstractUnityOfWork, AbstractUnityOfWork>();
        }
    }
}