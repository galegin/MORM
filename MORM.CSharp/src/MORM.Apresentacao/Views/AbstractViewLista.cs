using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using MORM.Infra.CrossCutting;
using System;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
{
    public class AbstractViewLista : AbstractView
    {
        #region construtores
        protected AbstractViewLista(IAbstractViewModelLista vm) : base(vm)
        {
        }
        #endregion
    }

    /*
    Lista de ...

    [ Fechar ] [ Limpar ] [ Listar ] [ Retornar ]

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
        where TViewModel : IAbstractViewModel
    {
        #region construtores
        private AbstractViewLista() : base(null)
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
                nameof(vm.IsExibirLimpar),
                nameof(vm.IsExibirListar),
                nameof(vm.IsExibirRetornar),
            });

            AddPainel(new DockPanel());

            AddPainel(new AbstractTitulo("Lista de " + vm.GetTitulo()), dock: Dock.Top);

            AddPainel(new AbstractOpcao(vm), dock: Dock.Top);

            AddPainel(new AbstractBusca(vm), dock: Dock.Top);

            AddPainel(new AbstractLista(vm));
        }

        public static object Execute(object objeto)
        {
            var viewLista = new AbstractViewLista<TViewModel>();

            if (TelaUtils.Instance.AbrirDialog(viewLista, isFullScreen: true) == true)
                return null;

            var vmLista = viewLista.DataContext as IAbstractViewModel;
            if (!vmLista.IsConfirmado)
                return null;

            return ObjetoMapper.GetObjetoRetorno(vmLista.Model.GetType(), vmLista.Model);
        }
        #endregion
    }
}