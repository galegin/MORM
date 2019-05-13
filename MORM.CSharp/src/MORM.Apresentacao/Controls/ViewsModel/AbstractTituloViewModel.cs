using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Controls.ViewsModel
{
    public class AbstractTituloViewModel : AbstractViewModel
    {
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

        #region construtores
        public AbstractTituloViewModel(string titulo)
        {
            Titulo = titulo;
        }
        #endregion
    }
}