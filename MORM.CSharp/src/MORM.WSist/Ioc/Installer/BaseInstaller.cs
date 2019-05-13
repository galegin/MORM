using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Aplicacao.Ioc.Installer;
using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Menus;
using MORM.Apresentacao;
using MORM.WSist.Menus;
using MORM.WSist.Views.Manutencao;
using MORM.WSist.Views.Lista;

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

        public override void InstallerConexao()
        {
        }

        public override void InstallerDataConext()
        {
        }

        public override void InstallerDomainServices()
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

        public override void InstallerViews()
        {
            RegisterSingleton<IMainWindow, MainWindow>();
            RegisterSingleton<IMainLogin, MainLogin>();

            Register<IMenuSistema, MenuSistema>();
            Register<IMenuLateral, ucMenuLateral>();
            Register<ITituloSistema, ucTituloSistema>();

            Register<IMenuResolverClasse, MenuResolverClasse>();
            Register<IMenuResolverObjeto, MenuResolverObjeto>();
            Register<IMenuResolverTipo, MenuResolverTipo>();

            Register<IAbstractClienteViewManut, AbstractClienteViewManut>();
            Register<IAbstractEmpresaViewManut, AbstractEmpresaViewManut>();
            Register<IAbstractProdutoViewManut, AbstractProdutoViewManut>();
            Register<IAbstractTerminalViewManut, AbstractTerminalViewManut>();
            Register<IAbstractUsuarioViewManut, AbstractUsuarioViewManut>();

            Register<IAbstractPackIconViewLista, AbstractPackIconViewLista>();
        }
    }
}