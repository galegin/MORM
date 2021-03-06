﻿using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Ioc.Container;
using MORM.Utils.Classes;
using System.Windows;

namespace MORM.Apresentacao
{
    public partial class App : Application
    {
        public App()
        {
            AbstractApplicationExtensions.SetApplication(this);
            NavegacaoComEnter.Ativar();
            Logger.Info("Entrada no sistema");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = BaseContainer.Instance.Resolve<IMainWindow>();
            mainWindow.SetContainer(BaseContainer.Instance);
            mainWindow.ShowDialog();
        }
    }
}