using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Menus.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Apresentacao.Menus
{
    public partial class ucMenuLateral : AbstractUserControlNotify, IMenuLateral
    {
        #region construtores
        public ucMenuLateral(IMenuSistema menuSistema)
        {
            InitializeComponent();
            DataContext = new MenuLateralViewModel();
            SetListaDeMenuOpcao(menuSistema.GetListaDeMenuOpcao());
        }
        #endregion

        #region metodos
        private void SetListaDeMenuOpcao(IList<IMenuOpcao> listaDeMenuOpcao)
        {
            stkMenuOpcao.Children.Clear();
            if (listaDeMenuOpcao != null)
                listaDeMenuOpcao.ToList().ForEach(menuOpcao => 
                {
                    stkMenuOpcao.Children.Add(new ucMenuOpcao(menuOpcao));
                });
        }
        public void SetarIsExibirMenuLateral(bool? flag = null)
        {
            (DataContext as MenuLateralViewModel).SetarIsExibirMenuLateral(flag);
        }
        #endregion
    }
}