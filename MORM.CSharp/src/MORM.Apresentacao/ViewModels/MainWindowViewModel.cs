using MORM.Apresentacao.Menus;
using System;

namespace MORM.Apresentacao.ViewModels
{
    public class MainWindowViewModel : AbstractViewModel
    {
        #region contrutores
        public MainWindowViewModel(
            ITituloSistema tituloSistema,
            IMenuLateral menuLateral,
            IMainWindowExec mainWindowExec)
        {
            TituloSistema = tituloSistema ?? throw new ArgumentNullException(nameof(tituloSistema));
            MenuLateral = menuLateral ?? throw new ArgumentNullException(nameof(menuLateral));
            MainWindowExec = mainWindowExec ?? throw new ArgumentNullException(nameof(mainWindowExec));
        }
        #endregion

        #region constantes
        #endregion

        #region variaveis
        private ITituloSistema _tituloSistema;
        private IMenuLateral _menuLateral;
        private IMainWindowExec _mainWindowExec;
        private object _corpo;
        #endregion

        #region propriedades
        public ITituloSistema TituloSistema
        {
            get => _tituloSistema;
            set => SetField(ref _tituloSistema, value);
        }
        public IMenuLateral MenuLateral
        {
            get => _menuLateral;
            set => SetField(ref _menuLateral, value);
        }
        public IMainWindowExec MainWindowExec
        {
            get => _mainWindowExec;
            set => SetField(ref _mainWindowExec, value);
        }
        public object Corpo
        {
            get => _corpo;
            set => SetField(ref _corpo, value);
        }
        #endregion

        #region comandos
        #endregion

        #region metodos
        #endregion
    }
}