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
        #endregion
    }

    #region extensions
    public static class AbstractViewListaExtensions
    {
        public static object Execute(Type classe, object objeto)
        {
            var viewLista = TypeForConvert
                .GetObjectFor(typeof(AbstractViewLista<>), classe) as AbstractViewLista;

            if (TelaUtils.Instance.AbrirDialog(viewLista, isFullScreen: true) == true)
                return null;

            var vmLista = viewLista.DataContext as IAbstractViewModel;
            if (!vmLista.IsConfirmado)
                return null;

            return ObjetoMapper.GetObjetoRetorno(vmLista.Model.GetType(), vmLista.Model);
        }

        public static object Execute<TViewModel>(object objeto)
            where TViewModel : IAbstractViewModel
        {
            return Execute(typeof(TViewModel), objeto);
        }
    }
    #endregion
}