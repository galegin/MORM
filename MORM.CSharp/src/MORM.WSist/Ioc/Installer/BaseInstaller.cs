using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Aplicacao.Ioc.Installer;
using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Menus;
using MORM.Apresentacao;
using MORM.WSist.Views.Manutencao;
using MORM.WSist.Menus;

namespace MORM.WSist.Ioc.Installer
{
    public class BaseInstaller : AbstractInstaller
    {
        public override void InstallerAmbiente()
        {
            Register<IAmbiente, Ambiente>();
            Register<IUsuario, Usuario>();
            Register<IEmpresa, Empresa>();
            Register<ITerminal, Terminal>();
            Register<IInformacaoSistema, InformacaoSistema>();
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
        }

        public override void InstallerUnitOfWork()
        {
        }

        public override void InstallerViewModels()
        {
        }

        public override void InstallerViews()
        {
            RegisterSingleton<IMainWindow, MainWindow>();

            Register<IMenuSistema, MenuSistema>();
            Register<IMenuLateral, ucMenuLateral>();
            Register<ITituloSistema, ucTituloSistema>();

            Register<IMenuResolverClasse, MenuResolverClasse>();
            Register<IMenuResolverObjeto, MenuResolverObjeto>();
            Register<IMenuResolverTipo, MenuResolverTipo>();

            Register<IAbstractClienteViewManut, AbstractClienteViewManut>();
            Register<IAbstractProdutoViewManut, AbstractProdutoViewManut>();
        }
    }
}