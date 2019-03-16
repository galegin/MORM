using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Ioc.Container;
using MORM.Utilidade.Utils;
using System.Windows;

namespace MORM.Apresentacao
{
    public partial class App : Application
    {
        public App()
        {
            AbstractApplicationExtensions.SetApplication(this);
            NavegacaoComEnter.Ativar();
            Logger.CreateDirLog();
            Logger.InfoMensagem("Entrada no sistema");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = AbstractAppContainer.Instance.Resolve<IMainWindow>();
            mainWindow.SetContainer(AbstractAppContainer.Instance);
            mainWindow.ShowDialog();
        }
    }
}