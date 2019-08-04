using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Extensions;
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

        public AbstractLista(IAbstractViewModel vm) : this()
        {
            CreateComps(vm);
        }

        private void CreateComps(IAbstractViewModel vm)
        {
            DataContext = vm;

            this.AddPainel(new DockPanel());

            var bindingLista = new Binding(nameof(vm.Lista)) { Source = vm };
            var bindingModel = new Binding(nameof(vm.Model)) { Source = vm };

            var dataGrid = new DataGrid()
            {
                Margin = new Thickness(10),
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                AutoGenerateColumns = false,
            };
            dataGrid.SetBinding(DataGrid.ItemsSourceProperty, bindingLista);
            dataGrid.SetBinding(DataGrid.SelectedItemProperty, bindingModel);
            this.AddPainel(dataGrid);

            //var style = FindResource("DataGridCellStyle") as Style;

            vm.ElementType
                .GetProperties()
                .Where(p => !p.IsIgnoreCampo())
                .ToList()
                .ForEach(prop =>
                {
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