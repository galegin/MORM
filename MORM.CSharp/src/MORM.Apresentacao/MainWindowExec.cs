using System;
using System.Windows.Controls;
using MORM.Ioc.Container;

namespace MORM.Apresentacao
{
    public class MainWindowExec : IMainWindowExec
    {
        #region variaveis
        private IMainWindow _mainWindow;
        #endregion

        #region propriedades
        public IAbstractContainer Container { get; private set; }
        #endregion

        #region metodos
        public void SetMainWindow(IMainWindow mainWindow)
        {
            _mainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
        }
        public void Navegar(object sender)
        {
            _mainWindow?.SetarIsExibirMenuLateral(flag: false);
            _mainWindow?.Navegar(sender);
        }
        public void SetarIsExibirMenuLateral()
        {
            _mainWindow?.SetarIsExibirMenuLateral();
        }
        public void SetContainer(IAbstractContainer container)
        {
            Container = container;
        }
        #endregion
    }
}