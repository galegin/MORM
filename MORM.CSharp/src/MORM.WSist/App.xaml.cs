﻿using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Connectors;
using MORM.Utils.Classes;
using MORM.WSist.Ioc.Container;
using System.Windows;

namespace MORM.WSist
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
            TelaUtils.Factory(BaseContainer.Instance).MainWindow.Execute(null);
        }
    }
}