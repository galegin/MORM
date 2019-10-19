namespace MORM.Apresentacao
{
    public class LoadingBoxViewModel : AbstractViewModel
    {
        #region variaveis
        private string _mensagem;
        #endregion

        #region propriedades
        public string Mensagem
        {
            get => _mensagem;
            set => SetField(ref _mensagem, value);
        }
        #endregion
    }
}