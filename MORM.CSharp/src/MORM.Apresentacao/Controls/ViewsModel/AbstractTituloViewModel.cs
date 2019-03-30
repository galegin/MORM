using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Controls.ViewsModel
{
    public class AbstractTituloViewModel : AbstractViewModel
    {
        #region constantes
        #endregion

        #region variaveis
        public string _titulo;
        #endregion

        #region propriedades
        public string Titulo
        {
            get => _titulo;
            set => SetField(ref _titulo, value);
        }
        #endregion

        #region comandos
        #endregion

        #region contrutores
        public AbstractTituloViewModel(string titulo)
        {
            Titulo = titulo;
        }
        #endregion

        #region metodos
        #endregion
    }
}