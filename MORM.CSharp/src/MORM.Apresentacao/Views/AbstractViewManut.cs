using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
        #region variaveis
        private AbstractViewTipo _tipo = AbstractViewTipo.ListaManutencao;
        private const string _consulta = "Consulta";
        private const string _cadastro = "Cadastro";
        private const string _filtro = "Filtro";
        private const string _relatorio = "Relatorio";
        private AbstractOpcao _opcao;
        #endregion

        #region construtores
        public AbstractViewManut() : base(null)
        {
            SetAbstractViewTipo();
            CreateComps(Activator.CreateInstance<TViewModel>());
        }
        #endregion

        #region metodos
        protected void CreateComps(IAbstractViewModel vm)
        {
            SetDataContext(vm);

            this.AddPainel(new DockPanel());

            this.AddPainel(new AbstractTitulo(_tipo.GetDescricao() + " de " + vm.GetTitulo()), dock: Dock.Top);

            this.AddPainel(_opcao = new AbstractOpcao(vm), dock: Dock.Top);

            this.AddPainel(new AbstractCorpo(GetUserControls(vm), OnHabilitarOpcao));
        }

        private void SetAbstractViewTipo()
        {
            _tipo = _tipo.GetAbstractViewTipoPadrao();
        }

        private void OnHabilitarOpcao(object sender, SelectionChangedEventArgs e)
        {
            var parameter = GetParameter(sender);

            var vm = DataContext as IAbstractViewModel;

            vm.OnHabilitarOpcao(_opcao,
                isExibirConsulta: _tipo.IsConsulta() && _consulta.Equals(parameter),
                isExibirCadastro: _tipo.IsCadastro() && _cadastro.Equals(parameter),
                isExibirFiltro: _tipo.IsFiltro() && _filtro.Equals(parameter),
                isExibirRelatorio: _tipo.IsRelatorio() && _filtro.Equals(parameter)
                );
        }

        private object GetParameter(object sender)
        {
            var tabControl = sender as TabControl;
            var tabItem = tabControl?.SelectedItem as TabItem;
            return tabItem?.Header ??
                (_tipo.IsConsulta() ? _consulta : null) ??
                (_tipo.IsCadastro() ? _cadastro : null) ??
                (_tipo.IsFiltro() ? _filtro : null) ??
                (_tipo.IsRelatorio() ? _relatorio : null)
                ;
        }

        private List<AbstractViewItem> GetUserControls(IAbstractViewModel vm)
        {
            return new List<AbstractViewItem>
            {
                _tipo.IsConsulta() ? new AbstractViewItem(_consulta, new AbstractBusca(vm), new AbstractLista(vm)) : null,
                _tipo.IsCadastro() ? new AbstractViewItem(_cadastro, new AbstractManut(vm)) : null,
                _tipo.IsFiltro() ? new AbstractViewItem(_filtro, new AbstractFiltro(vm)) : null,
                _tipo.IsRelatorio() ? new AbstractViewItem(_relatorio, new AbstractRelatorio(vm)) : null,
            }
            .Where(x => x != null)
            .ToList()
            ;
        }
        #endregion
    }
}