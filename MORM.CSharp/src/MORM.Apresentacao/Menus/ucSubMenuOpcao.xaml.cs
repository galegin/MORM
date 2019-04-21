using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Menus.ViewModels;

namespace MORM.Apresentacao.Menus
{
    public partial class ucSubMenuOpcao : AbstractUserControl
    {
        #region construtores
        public ucSubMenuOpcao(IMenuOpcao menuOpcao)
        {
            InitializeComponent();
            DataContext = new SubMenuOpcaoViewModel(menuOpcao);
        }
        #endregion
    }
}