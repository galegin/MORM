using MORM.Apresentacao.Menus;
using MORM.Ioc.Installer;

namespace MORM.Apresentacao.Ioc.Installer
{
    public class AbstractAppWindow : AbstractInstaller
    {
        protected override void Setup()
        {
            RegisterSingleton<IMainWindow, MainWindow>();
            RegisterSingleton<IMainWindowExec, MainWindowExec>();

            Register<IMenuSistema, MenuSistema>();
            Register<IMenuLateral, ucMenuLateral>();
            Register<ITituloSistema, ucTituloSistema>();

            Register<IMenuResolverClasse, MenuResolverClasse>();
            Register<IMenuResolverObjeto, MenuResolverObjeto>();
            Register<IMenuResolverTipo, MenuResolverTipo>();
        }
    }
}