using MORM.CrossCutting;
using System.Windows;

namespace MORM.Apresentacao.WSist
{
    public partial class App : Application
    {
        static App()
        {
            AbstractApplicationExtensions.ApenasUmaCopia();
            var container = AbstractContainer.Instance;
            container.AddInstaller();
        }

        public App()
        {
            AbstractAmbienteConnector.ValidarAcesso();
            AbstractApplicationExtensions.SetApplication(this);
            NavegacaoComEnter.Ativar();
            Logger.Info("Entrada no sistema");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            TelaUtils.Instance.MainWindow.Execute();
        }
    }
}