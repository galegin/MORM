using MORM.Apresentacao.Comps.Interfaces;
using MORM.Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Comps
{
    public class TelaUtils : ITelaUtils
    {
        #region variavies
        private List<UserControl> _lista = new List<UserControl>();
        #endregion

        #region propriedades
        public static ITelaUtils Instance { get; private set; }
        public IAbstractContainer Container { get; private set; }
        public IMainCommand MainCommand => Container.Resolve<IMainCommand>();
        public IMainWindow MainWindow => Container.Resolve<IMainWindow>();
        public IMainLogin MainLogin => Container.Resolve<IMainLogin>();
        public IMainMensagem MainMensagem => Container.Resolve<IMainMensagem>();
        #endregion

        #region metodos
        public static ITelaUtils Factory(IAbstractContainer container)
        {
            return Instance ?? (Instance = new TelaUtils { Container = container });
        }

        public void NavegarPara(UserControl userControl)
        {
            if (MainWindow != null)
            {
                if (userControl != null)
                    _lista.Add(userControl);
                MainWindow.SetarIsExibirMenuLateral(flag: false);
                MainWindow.Navegar(userControl);
            }
        }

        public void VoltarTela(bool isAnterior = false)
        {
            if (isAnterior)
                _lista.RemoveAt(_lista.Count - 1);
            else
                _lista.Clear();

            var userControl = isAnterior ? _lista.FirstOrDefault() : _lista.LastOrDefault();

            NavegarPara(userControl);
        }

        public void VoltarTelaAnterior() => VoltarTela(isAnterior: true);
        public void VoltarTelaInicio() => VoltarTela(isAnterior: false);

        public bool? AbrirDialog(UserControl userControl, bool isFullScreen = false)
        {
            var defaultWindow = new AbstractWindow();
            defaultWindow.Content = userControl;
            defaultWindow.ShowInTaskbar = false;

            if (isFullScreen)
                defaultWindow.WindowState = WindowState.Maximized;
            else
            {
                defaultWindow.SizeToContent = SizeToContent.WidthAndHeight;
                defaultWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

            return defaultWindow.ShowDialog();
        }

        public void SetarIsExibirMenuLateral(bool? flag = null)
        {
            MainWindow?.SetarIsExibirMenuLateral(flag);
        }
        #endregion
    }
}