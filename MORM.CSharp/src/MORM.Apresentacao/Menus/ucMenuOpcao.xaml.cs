﻿using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Menus.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Apresentacao.Menus
{
    public partial class ucMenuOpcao : AbstractUserControlNotify
    {
        #region construtores
        public ucMenuOpcao(IMenuOpcao menuOpcao)
        {
            InitializeComponent();
            DataContext = new MenuOpcaoViewModel(menuOpcao);
            SetSubMenuOpcao(menuOpcao.SubMenuOpcao);
        }
        #endregion

        #region metodos
        private void SetSubMenuOpcao(IList<IMenuOpcao> listaDeSubMenuOpcao)
        {
            stkSubMenuOpcao.Children.Clear();
            if (listaDeSubMenuOpcao != null)
                listaDeSubMenuOpcao.ToList().ForEach(subMenuOpcao =>
                {
                    stkSubMenuOpcao.Children.Add(new ucSubMenuOpcao(subMenuOpcao));
                });
        }
        #endregion
    }
}