using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System;
using System.Collections;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
{
    public abstract class AbstractViewLista : AbstractView
    {
        #region variaveis
        //protected IAbstractViewModel _vm => DataContext as IAbstractViewModel;
        #endregion

        #region propriedades
        //public IList Valores
        //{
        //    get => _vm.Valores;
        //    set => _vm.Valores = value;
        //}
        #endregion

        #region construtores
        protected AbstractViewLista(IAbstractViewModelLista vm) : base(vm)
        {
        }
        #endregion

        #region metodos
        //public abstract void SetSelecao();
        //public abstract void SetValores(IList valores);
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
        public AbstractViewLista(IList valores = null, bool isSelecao = false) : base(null)
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

            this.AddPainel(new DockPanel());

            this.AddPainel(new AbstractTitulo("Lista de " + vm.GetTitulo()), dock: Dock.Top);

            this.AddPainel(new AbstractOpcao(vm), dock: Dock.Top);

            this.AddPainel(new AbstractBusca(vm), dock: Dock.Top);

            this.AddPainel(new AbstractLista(vm));
        }

        //public override void SetSelecao()
        //{

        //}

        //public override void SetValores(IList valores)
        //{

        //}
        #endregion
    }
}