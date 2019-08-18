﻿using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Views;
using MORM.Apresentacao.ViewsModel;
using MORM.Infra.CrossCutting;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractLista : AbstractUserControl
    {
        public AbstractLista()
        {
            InitializeComponent();
        }

        public AbstractLista(IAbstractViewModel vm, object filtro = null) : this()
        {
            CreateComps(vm);
        }

        private void CreateComps(IAbstractViewModel vm, object filtro = null)
        {
            DataContext = vm;

            this.AddPainel(new DockPanel());

            if (filtro != null)
            {
                this.AddPainel(filtro, dock: Dock.Top);
            }

            var bindingLista = new Binding(nameof(vm.Lista)) { Source = vm };
            var bindingModel = new Binding(nameof(vm.Model)) { Source = vm };

            var dataGrid = new DataGrid()
            {
                Margin = new Thickness(10),
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                AutoGenerateColumns = false,
                CanUserAddRows = false,
                CanUserDeleteRows = false,
                IsReadOnly = true,
            };
            dataGrid.SetBinding(DataGrid.ItemsSourceProperty, bindingLista);
            dataGrid.SetBinding(DataGrid.SelectedItemProperty, bindingModel);
            this.AddPainel(dataGrid);

            //var style = FindResource("DataGridCellStyle") as Style;

            vm.ElementType
                .GetMetadata()
                .Campos
                .Where(p => !p.Prop.IsIgnoreCampo())
                .ToList()
                .ForEach(campo =>
                {
                    var descricao = campo.Descricao;
                    var formato = campo.Formato;

                    var bindingDataGridColumn = new Binding(campo.Prop.Name)
                    {
                        StringFormat = (!string.IsNullOrWhiteSpace(formato) ? formato : null),
                    };

                    dataGrid.Columns.Add(new DataGridTextColumn()
                    {
                        Header = descricao,
                        Binding = bindingDataGridColumn,
                        //CellStyle = style,
                    });
                });
        }
    }
}