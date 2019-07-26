using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Extensions;
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

        public AbstractLista(IAbstractViewModel vm) : this()
        {
            CreateComps(vm);
        }

        private void CreateComps(IAbstractViewModel vm)
        {
            DataContext = vm;

            var dockPanel = new DockPanel();
            dockPanel.Margin = new Thickness(10);
            Content = dockPanel;

            var bindingLista = new Binding(nameof(vm.Lista)) { Source = vm };
            var bindingModel = new Binding(nameof(vm.Model)) { Source = vm };

            var dataGrid = new DataGrid();
            dataGrid.Margin = new Thickness(10);
            dataGrid.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            dataGrid.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            dataGrid.AutoGenerateColumns = false;
            dataGrid.SetBinding(DataGrid.ItemsSourceProperty, bindingLista);
            dataGrid.SetBinding(DataGrid.SelectedItemProperty, bindingModel);
            dockPanel.Children.Add(dataGrid);

            //var style = FindResource("DataGridCellStyle") as Style;

            vm.Model.GetType().GetProperties().ToList().ForEach(prop =>
            {
                if (prop.IsIgnoreCampo())
                    return;

                var descricao = prop.GetDescricao().GetTraducao();
                var formato = prop.GetFormato();

                var bindingDataGridColumn = new Binding(prop.Name)
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