using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Aplicacao.Ioc.Installer;
using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Commands.Manutencao;
using MORM.Apresentacao.Models.Manutencao;
using MORM.Apresentacao.ViewModels.Manutencao;
using MORM.Apresentacao.Views.Manutencao;
using MORM.Apresentacao.Menus;

namespace MORM.Apresentacao.Ioc.Installer
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
            Register<IAbstractClienteManutCommand, AbstractClienteManutCommand>();
            Register<IAbstractProdutoManutCommand, AbstractProdutoManutCommand>();
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
            Register<IAbstractClienteModel, AbstractClienteModel>();
            Register<IAbstractProdutoModel, AbstractProdutoModel>();
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
            RegisterSingleton<IMainWindowExec, MainWindowExec>();

            Register<IMenuSistema, MenuSistema>();
            Register<IMenuLateral, ucMenuLateral>();
            Register<ITituloSistema, ucTituloSistema>();

            Register<IMenuResolverClasse, MenuResolverClasse>();
            Register<IMenuResolverObjeto, MenuResolverObjeto>();
            Register<IMenuResolverTipo, MenuResolverTipo>();

            Register<IAbstractClienteViewModel, AbstractClienteViewModel>();
            Register<IAbstractClienteViewManut, AbstractClienteViewManut>();
            Register<IAbstractProdutoViewModel, AbstractProdutoViewModel>();
            Register<IAbstractProdutoViewManut, AbstractProdutoViewManut>();
        }
    }
}