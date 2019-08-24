using System.Linq;
using System.Windows;

namespace MORM.Apresentacao.Comps
{
    public static class AbstractAppAction
    {
        #region variaveis
        private static Window _currentWindow;
        private static Window CurrentWindow => _currentWindow ??
            (_currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive));
        #endregion

        #region propriedades
        public static bool IsActiveApp { get; set; }
        #endregion

        #region construtores
        static AbstractAppAction()
        {
            IsActiveApp = true;
        }
        #endregion

        #region metodos
        public static void MinimizarApp(this object obj)
        {
            if (CurrentWindow == null)
                return;

            CurrentWindow.ShowInTaskbar = false;
            CurrentWindow.Hide();
            IsActiveApp = false;
        }

        public static void RestaurarApp(this object obj)
        {
            if (CurrentWindow == null)
                return;

            CurrentWindow.ShowInTaskbar = true;
            CurrentWindow.Show();
            IsActiveApp = true;

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