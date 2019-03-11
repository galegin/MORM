using System;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public class MainWindowExec : IMainWindowExec
    {
        #region variaveis
        private IMainWindow _mainWindow;
        #endregion

        #region metodos
        public void SetMainWindow(IMainWindow mainWindow)
        {
            _mainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
        }
        public void Navegar(UserControl userControl)
        {
            _mainWindow?.SetarIsExibirMenuLateral(flag: false);
            _mainWindow?.Navegar(userControl);
        }
        public void SetarIsExibirMenuLateral()
        {
            _mainWindow?.SetarIsExibirMenuLateral();
        }
        #endregion
    }
}