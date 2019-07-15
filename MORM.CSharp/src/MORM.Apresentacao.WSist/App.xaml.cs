using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Connectors;
using MORM.Infra.CrossCutting;
using System.Windows;

namespace MORM.Apresentacao.WSist
{
    public partial class App : Application
    {
        public App()
        {
            AbstractAmbienteConnector.ValidarAcesso();
            AbstractApplicationExtensions.SetApplication(this);
            NavegacaoComEnter.Ativar();
            Logger.CreateDirLog();
            Logger.InfoMensagem("Entrada no sistema");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            TelaUtils.Factory(BaseInstaller.Container).MainWindow.Execute(null);
        }
    }
}
