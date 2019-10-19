namespace MORM.Apresentacao
{
    public class LoginModel : AbstractModel
    {
        #region variaveis
        private string _login;
        private string _senha;
        #endregion

        #region propriedades
        public string Login
        {
            get => _login;
            set => SetField(ref _login, value);
        }
        public string Senha
        {
            get => _senha;
            set => SetField(ref _senha, value);
        }
        #endregion
    }
}