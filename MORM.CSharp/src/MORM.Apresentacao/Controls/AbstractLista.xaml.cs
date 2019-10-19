using MORM.CrossCutting;
using System.Windows.Controls;

namespace MORM.Apresentacao
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

            var dataGrid = new AbstractDataGrid(isReadOnly: !selecao?.IsSelecao ?? true);
            dataGrid.SetBindingDataGridLista(vm);
            dataGrid.SetBindingDataGridModel(vm);
            this.AddPainel(dataGrid);

            //var style = FindResource("DataGridCellStyle") as Style;

            GetMetadata(vm, selecao)
                .GetCamposIgnore()
                .ForEach(campo =>
                {
                    campo.IsEditar = selecao.IsEditavel(campo.Prop.Name);
                    dataGrid.Columns.Add(GetDataGridColumn(campo));
                });
        }

        private DataGridColumn GetDataGridColumn(MetadataCampo campo)
        {
            var tipoDado = campo.Prop.GetTipoDadoModel();

            switch (tipoDado.Dado)
            {
                case TipoDado.Bool:
                    return GetDataGridCheckBoxColumn(campo);
                default:
                    return GetDataGridTextBoxColumn(campo);
            }
        }

        private DataGridCheckBoxColumn GetDataGridCheckBoxColumn(MetadataCampo campo)
        {
            return new DataGridCheckBoxColumn()
            {
                Header = campo.Descricao,
                Binding = campo.GetBindingCampo(),
                IsReadOnly = !campo.IsEditar,
                //CellStyle = style,
            };
        }

        private DataGridTextColumn GetDataGridTextBoxColumn(MetadataCampo campo)
        {
            return new DataGridTextColumn()
            {
                Header = campo.Descricao,
                Binding = campo.GetBindingCampo(),
                IsReadOnly = !campo.IsEditar,
                //CellStyle = style,
            };
        }

        private Metadata GetMetadata(IAbstractViewModel vm, 
            AbstractSelecao selecao = null)
        {
            return selecao != null ? selecao.GetMetadata(vm) : 
                vm.ElementType.GetMetadata();
        }
    }
}