using System.Linq;
using System.Windows;

namespace MORM.Apresentacao.Comps
{
    public static class AbstractAppAction
    {
        #region variaveis
        private static Window _currentWindow;
        #endregion

        #region propriedades
        public static Window CurrentWindow => _currentWindow ?? (_currentWindow = GetWindowActive());
        public static AbstractWindow AbstractWindow => CurrentWindow as AbstractWindow;
        public static bool IsActiveApp { get; private set; }
        #endregion

        #region construtores
        static AbstractAppAction()
        {
            IsActiveApp = true;
        }
        #endregion

        #region metodos
        private static Window GetWindowActive()
        {
            return Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        }

        public static void MinimizarApp(this object obj)
        {
            if (CurrentWindow == null)
                return;

            CurrentWindow.ShowInTaskbar = false;
            CurrentWindow.Hide();
            IsActiveApp = false;

            if (AbstractWindow != null)
            {
                AbstractWindow.SetarNotifyIcon();
                AbstractWindow.NotifyIcon.Ativo = true;
            }
        }

        public static void RestaurarApp(this object obj)
        {
            if (CurrentWindow == null)
                return;

            CurrentWindow.ShowInTaskbar = true;
            CurrentWindow.Show();
            IsActiveApp = true;

            if (AbstractWindow != null)
                AbstractWindow.NotifyIcon.Ativo = false;

            _currentWindow = null;
        }

        public static void FinalizarApp(this object obj)
        {
            if (CurrentWindow == null)
                return;

            CurrentWindow.Close();
        }
        #endregion
    }
}