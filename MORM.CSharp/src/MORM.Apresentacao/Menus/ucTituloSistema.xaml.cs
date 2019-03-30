using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Menus.ViewModels;
using MORM.Dominio.Interfaces;

namespace MORM.Apresentacao.Menus
{
    public partial class ucTituloSistema : AbstractUserControlNotify, ITituloSistema
    {
        #region construtores
        public ucTituloSistema(
            IInformacaoSistema informacaoSistema)
        {
            InitializeComponent();
            DataContext = new TituloSistemaViewModel(informacaoSistema);
        }
        #endregion
    }
}