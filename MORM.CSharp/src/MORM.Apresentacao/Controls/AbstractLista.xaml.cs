﻿using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Views;
using MORM.Apresentacao.ViewsModel;
using MORM.Infra.CrossCutting;
using System.Windows.Controls;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractLista : AbstractUserControl
    {
        public AbstractLista()
        {
            InitializeComponent();
        }

        public AbstractLista(IAbstractViewModel vm, object filtro = null,
            AbstractSelecao selecao = null) : this()
        {
            CreateComps(vm, filtro, selecao);
        }

        private void CreateComps(IAbstractViewModel vm, object filtro = null,
            AbstractSelecao selecao = null)
        {
            DataContext = vm;

            this.AddPainel(new DockPanel());

            if (filtro != null)
            {
                this.AddPainel(filtro, dock: Dock.Top);
            }

            var dataGrid = new AbstractDataGrid();
            dataGrid.SetBindingDataGridLista(vm);
            dataGrid.SetBindingDataGridModel(vm);
            this.AddPainel(dataGrid);

            //var style = FindResource("DataGridCellStyle") as Style;

            GetMetadata(vm, selecao)
                .GetCamposIgnore()
                .ForEach(campo =>
                {
                    dataGrid.Columns.Add(new DataGridTextColumn()
                    {
                        Header = campo.Descricao,
                        Binding = campo.GetBindingCampo(),
                        //CellStyle = style,
                    });
                });
        }

        private Metadata GetMetadata(IAbstractViewModel vm, 
            AbstractSelecao selecao = null)
        {
            return selecao != null ? selecao.GetMetadata(vm) : 
                vm.ElementType.GetMetadata();
        }
    }
}