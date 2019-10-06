using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Menus.ViewModels;
using MORM.CrossCutting;

namespace MORM.Apresentacao.Menus
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