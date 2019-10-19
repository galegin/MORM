using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace MORM.Apresentacao
{
    public class AbstractViewFiltro : AbstractView
    {
        #region construtores
        public AbstractViewFiltro(IAbstractViewModelManut vm) : base(vm)
        {
        }
        #endregion
    }

    /*
    Filtro de ...

    [ Limpar ] [ Salvar ] [ Confirmar ] [ Cancelar ]

    [ Codigo ] [          ] [          ]
    [ Nome   ] [                        ] [                        ]
    [ Data   ] [          ] [          ]
    [ Valor  ] [          ] [          ]
    */

    public class AbstractViewFiltro<TViewModel> : AbstractViewFiltro
        where TViewModel : IAbstractViewModel
    {
        #region construtores
        public AbstractViewFiltro() : base(null)
        {
            CreateComps(Activator.CreateInstance<TViewModel>());
        }
        #endregion

        #region metodos
        protected void CreateComps(IAbstractViewModel vm)
        {
            SetDataContext(vm);

            vm.ConfirmarAction = () => ConfirmarFiltro();
            vm.CancelarAction = () => CancelarFiltro();
            vm.Commands = GetCommands();

            this.AddPainel(new StackPanel());

            this.AddPainel(new AbstractTitulo("Filtro de " + vm.GetTitulo()));

            this.AddPainel(new AbstractOpcao(vm));

            this.AddPainel(new AbstractFiltro(vm));
        }

        public void ConfirmarFiltro()
        {
        }

        public void CancelarFiltro()
        {
        }

        private ICommand[] GetCommands()
        {
            var vm = DataContext as IAbstractViewModel;

            var mainCommand = vm.ElementType.GetMainCommand();

            return new ICommand[]
            {
                mainCommand.GetCommand(CommandTipo.Confirmar),
                mainCommand.GetCommand(CommandTipo.Cancelar),
                mainCommand.GetCommand(CommandTipo.Limpar),
                mainCommand.GetCommand(CommandTipo.Salvar),
            };
        }
        #endregion
    }
}