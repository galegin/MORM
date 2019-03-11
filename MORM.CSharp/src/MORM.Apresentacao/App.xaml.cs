using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Comps;
using MORM.Apresentacao.IoC.Container;
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
            var mainWindow = AbstractAppContainer.AbstractAppInstance.Resolve<IMainWindow>();
            mainWindow.ShowDialog();
        }
    }
}