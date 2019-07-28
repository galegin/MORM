using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
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

            vm.SetOpcoes(new[]
            {
                nameof(vm.IsExibirConfirmar),
                nameof(vm.IsExibirCancelar),
                nameof(vm.IsExibirSalvar),
                nameof(vm.IsExibirLimpar),
            });

            AddPainel(new StackPanel());

            AddPainel(new AbstractTitulo("Filtro de " + vm.GetTitulo()));

            AddPainel(new AbstractOpcao(vm));

            AddPainel(new AbstractFiltro(vm));
        }

        public void ConfirmarFiltro()
        {
        }

        public void CancelarFiltro()
        {
        }
        #endregion
    }
}