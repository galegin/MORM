using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
{
    public class AbstractViewLista : AbstractView
    {
        #region construtores
        public AbstractViewLista(IAbstractViewModelLista vm) : base(vm)
        {
        }
        #endregion
    }

    /*

    Lista de ...

    [ Limpar ] [ Consultar ]

    [ Expressão ] [                                 ]

    +--------+--------------------------------------+
    | Codigo | Descricao                            |
    +--------+--------------------------------------+
    | 999999 | XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX |
    | 999999 | XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX |
    | 999999 | XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX |
    | 999999 | XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX |
    | 999999 | XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX |
    | 999999 | XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX |
    | 999999 | XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX |
    +--------+--------------------------------------+

    */

    public class AbstractViewLista<TViewModel> : AbstractViewLista
    {
        #region construtores
        public AbstractViewLista() : base(null)
        {
            CreateComps(Activator.CreateInstance<TViewModel>() as IAbstractViewModel);
        }
        #endregion

        #region metodos
        protected void CreateComps(IAbstractViewModel vm)
        {
            SetDataContext(vm);

            vm.SetOpcoes(new[] 
            {
                nameof(vm.IsExibirFechar),
                nameof(vm.IsExibirVoltar),
                nameof(vm.IsExibirLimpar),
                nameof(vm.IsExibirListar),
                nameof(vm.IsExibirRetornar),
            });

            var dockPanel = new DockPanel();
            dockPanel.Margin = new Thickness(10);
            Content = dockPanel;

            var userControlTitulo = new AbstractTitulo("Lista de " + vm.GetTituloModel());
            userControlTitulo.Margin = new Thickness(0, 0, 0, 10);
            DockPanel.SetDock(userControlTitulo, Dock.Top);
            dockPanel.Children.Add(userControlTitulo);

            var userControlOpcao = new AbstractOpcao(vm);
            userControlOpcao.Margin = new Thickness(0, 0, 0, 10);
            DockPanel.SetDock(userControlOpcao, Dock.Top);
            dockPanel.Children.Add(userControlOpcao);

            var userControlBusca = new AbstractBusca(vm);
            userControlBusca.Margin = new Thickness(0, 0, 0, 10);
            DockPanel.SetDock(userControlBusca, Dock.Top);
            dockPanel.Children.Add(userControlBusca);

            var userControlLista = new AbstractLista(vm);
            userControlLista.Margin = new Thickness(0, 0, 0, 10);
            dockPanel.Children.Add(userControlLista);
        }
        #endregion
    }
}