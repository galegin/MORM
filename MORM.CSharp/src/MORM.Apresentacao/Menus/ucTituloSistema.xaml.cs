using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Menus.ViewModels;
using MORM.Utilidade.Interfaces;

namespace MORM.Apresentacao.Menus
{
    public partial class ucTituloSistema : AbstractUserControlNotify, ITituloSistema
    {
        #region construtores
        public ucTituloSistema(
            IInformacaoSistema informacaoSistema,
            IMainWindowExec mainWindowExec)
        {
            InitializeComponent();
            DataContext = new TituloSistemaViewModel(informacaoSistema, mainWindowExec);
        }
        #endregion
    }
}