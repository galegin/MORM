using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Menus.ViewModels
{
    public class MenuLateralViewModel : AbstractViewModel
    {
        #region construtores
        #endregion

        #region variaveis
        private bool _isExibirMenuLateral;
        #endregion

        #region propriedades
        public bool IsExibirMenuLateral
        {
            get => _isExibirMenuLateral;
            set => SetField(ref _isExibirMenuLateral, value);
        }
        #endregion

        #region comandos
        #endregion

        #region metodos
        public void SetarIsExibirMenuLateral(bool? flag = null)
        {
            IsExibirMenuLateral = flag ?? !IsExibirMenuLateral;
        }
        #endregion
    }
}