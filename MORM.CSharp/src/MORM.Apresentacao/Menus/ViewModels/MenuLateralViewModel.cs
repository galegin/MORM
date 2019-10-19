namespace MORM.Apresentacao
{
    public class MenuLateralViewModel : AbstractViewModel
    {
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

        #region construtores
        #endregion

        #region metodos
        public void SetarIsExibirMenuLateral(bool? flag = null)
        {
            IsExibirMenuLateral = flag ?? !IsExibirMenuLateral;
        }
        #endregion
    }
}