using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using MORM.Infra.CrossCutting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace MORM.Apresentacao.Views
{
    public abstract class AbstractViewLista : AbstractView
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
        public AbstractViewLista(AbstractSelecao selecao = null) : base(null)
        {
            CreateComps(Activator.CreateInstance<TViewModel>(), selecao);
        }
        #endregion

        #region metodos
        protected void CreateComps(IAbstractViewModel vm,
            AbstractSelecao selecao = null)
        {
            SetDataContext(vm);

            this.AddPainel(new DockPanel());

            var preTitulo = (selecao?.IsSelecao ?? false) ? "Seleção" : "Lista";

            this.AddPainel(new AbstractTitulo(preTitulo + " de " + vm.GetTitulo()), dock: Dock.Top);

            this.AddPainel(new AbstractOpcao(vm, GetCommands()), dock: Dock.Top);

            this.AddPainel(new AbstractBusca(vm), dock: Dock.Top);

            this.AddPainel(new AbstractLista(vm, selecao: selecao));
        }

        private ICommand[] GetCommands()
        {
            var vm = DataContext as IAbstractViewModel;

            var mainCommand = vm.ElementType.GetMainCommand();

            return new ICommand[]
            {
                mainCommand.GetCommand(CommandTipo.Fechar),
                mainCommand.GetCommand(CommandTipo.Limpar),
                mainCommand.GetCommand(CommandTipo.Consultar),
                mainCommand.GetCommand(CommandTipo.Retornar),
            };
        }
        #endregion
    }
}