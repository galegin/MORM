using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Aplicacao.Ioc.Installer;
using MORM.Apresentacao.Classes;
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

        public override void InstallerViews()
        {
            //RegisterSingleton<IMainLogin, MainLogin>();
            //RegisterSingleton<IMainCommand, MainCommand>();
            RegisterSingleton<IMainWindow, MainWindow>();

            //Register<IMenuSistema, MenuSistema>();
            Register<IMenuLateral, ucMenuLateral>();
            Register<ITituloSistema, ucTituloSistema>();

            Register<IMenuResolverClasse, MenuResolverClasse>();
            Register<IMenuResolverObjeto, MenuResolverObjeto>();
            Register<IMenuResolverTipo, MenuResolverTipo>();
        }
    }
}