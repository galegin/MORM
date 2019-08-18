using MORM.Apresentacao.Comps;
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

            var dataGrid = new AbstractDataGrid();
            dataGrid.SetBindingDataGridLista(vm);
            dataGrid.SetBindingDataGridModel(vm);
            this.AddPainel(dataGrid);

            //var style = FindResource("DataGridCellStyle") as Style;

            vm.ElementType
                .GetMetadata()
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
    }
}