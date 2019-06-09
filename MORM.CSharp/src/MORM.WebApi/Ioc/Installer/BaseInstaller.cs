using MORM.Aplicacao.Ioc.Installer;
using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Context;
using MORM.Repositorio.Interfaces;
using MORM.Repositorio.Uow;
using MORM.Servico.Interfaces.nsAmbiente;
using MORM.Servico.Services.nsAmbiente;

namespace MORM.WebApi.Ioc
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
        }

        public override void InstallerDataConext()
        {
            Register<IAbstractDataContext, AbstractDataContext>();
        }

        public override void InstallerDomainServices()
        {
        }

        public override void InstallerRepositories()
        {
        }

        public override void InstallerServices()
        {
            Register<IAmbienteService, AmbienteService>();
            Register<IEmpresaService, EmpresaService>();
            Register<ITerminalService, TerminalService>();
            Register<IUsuarioService, UsuarioService>();
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