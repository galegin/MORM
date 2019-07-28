using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
{
    public class AbstractViewManut : AbstractView
    {
        #region construtores
        public AbstractViewManut(IAbstractViewModelManut vm) : base(vm)
        {
        }
        #endregion
    }

    /*
    Manutenção de ...

    [ Voltar ] [ Limpar ] [ Consultar ] [ Salvar ] [ Excluir ]

    [ Codigo ] [          ]
    [ Nome   ] [                        ]
    [ Data   ] [          ]
    [ Valor  ] [          ]
    */

    public class AbstractViewManut<TViewModel> : AbstractViewManut
        where TViewModel : IAbstractViewModel
    {
        #region construtores
        public AbstractViewManut() : base(null)
        {
            CreateComps(Activator.CreateInstance<TViewModel>());
        }
        #endregion

        #region metodos
        protected void CreateComps(IAbstractViewModel vm)
        {
            SetDataContext(vm);

            vm.SelecionarAction = () => SelecionarLista();

            vm.SetOpcoes(new[]
            {
                nameof(vm.IsExibirVoltar),
                nameof(vm.IsExibirLimpar),
                nameof(vm.IsExibirConsultar),
                nameof(vm.IsExibirSalvar),
                nameof(vm.IsExibirExcluir),
                nameof(vm.IsExibirSelecionar),
            });

            AddPainel(new StackPanel());

            AddPainel(new AbstractTitulo("Manutenção de " + vm.GetTitulo()));

            AddPainel(new AbstractOpcao(vm));

            AddPainel(new AbstractManut(vm));
        }

        public void SelecionarLista()
        {
            var vm = DataContext as IAbstractViewModel;
            var objeto = AbstractViewLista<TViewModel>.Execute(vm.Filtro);
            if (objeto != null)
                vm.Model = objeto;
        }
        #endregion
    }
}