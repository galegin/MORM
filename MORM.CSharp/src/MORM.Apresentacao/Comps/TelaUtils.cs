using MORM.CrossCutting;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public class TelaUtils : ITelaUtils
    {
        #region variavies
        private static ITelaUtils _instance;
        private List<UserControl> _lista = new List<UserControl>();
        #endregion

        #region propriedades
        public static ITelaUtils Instance => _instance ?? (_instance = new TelaUtils());
        public IAbstractContainer Container { get; }
        public IMainCommand MainCommand => Container.Resolve<IMainCommand>();
        public IMainWindow MainWindow => Container.Resolve<IMainWindow>();
        public IMainLogin MainLogin => Container.Resolve<IMainLogin>();
        public IMainMensagem MainMensagem => Container.Resolve<IMainMensagem>();
        #endregion

        #region construtores
        public TelaUtils()
        {
            Container = AbstractContainer.Instance;
        }
        #endregion

        #region metodos
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
            if (isAnterior && _lista.Count() > 1)
                _lista.RemoveAt(_lista.Count - 1);
            else
                _lista.Clear();

            var userControl = isAnterior ? _lista.FirstOrDefault() : _lista.LastOrDefault();

            NavegarPara(userControl);
        }

        public void VoltarTelaAnterior() => VoltarTela(isAnterior: true);
        public void VoltarTelaInicio() => VoltarTela(isAnterior: false);

        public bool? AbrirDialog(UserControl userControl, bool isFullScreen = false, bool isNoBorder = false)
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

            if (isNoBorder)
            {
                defaultWindow.BorderThickness = new Thickness(0);
                defaultWindow.WindowStyle = WindowStyle.None;
                defaultWindow.ResizeMode = ResizeMode.NoResize;
            }

            var confirma = defaultWindow.ShowDialog();

            return userControl is AbstractUserControl 
                ? (userControl as AbstractUserControl).InConfirmado
                : confirma
                ;
        }

        public void SetarIsExibirMenuLateral(bool? flag = null)
        {
            MainWindow?.SetarIsExibirMenuLateral(flag);
        }
        #endregion
    }
}