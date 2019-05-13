using MORM.Apresentacao.Menus;
using System;

namespace MORM.Apresentacao.ViewsModel
{
    public class MainWindowViewModel : AbstractViewModel
    {
        #region variaveis
        private ITituloSistema _tituloSistema;
        private IMenuLateral _menuLateral;
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
        public object Corpo
        {
            get => _corpo;
            set => SetField(ref _corpo, value);
        }
        #endregion

        #region construtores
        public MainWindowViewModel(
            ITituloSistema tituloSistema,
            IMenuLateral menuLateral)
        {
            TituloSistema = tituloSistema ?? throw new ArgumentNullException(nameof(tituloSistema));
            MenuLateral = menuLateral ?? throw new ArgumentNullException(nameof(menuLateral));
        }
        #endregion
    }
}