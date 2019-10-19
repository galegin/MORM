using MORM.CrossCutting;

namespace MORM.Apresentacao
{
    public partial class ucTituloSistema : AbstractUserControl, ITituloSistema
    {
        #region construtores
        public ucTituloSistema(IInformacaoSistema informacaoSistema)
        {
            InitializeComponent();
            DataContext = new TituloSistemaViewModel(informacaoSistema);
        }
        #endregion
    }
}