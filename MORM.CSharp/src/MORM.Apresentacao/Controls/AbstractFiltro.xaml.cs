using MORM.CrossCutting;

namespace MORM.Apresentacao
{
    public partial class AbstractFiltro : AbstractUserControl
    {
        public AbstractFiltro()
        {
            InitializeComponent();
        }

        public AbstractFiltro(IAbstractViewModel vm) : this()
        {
            CreateComps(vm);
        }

        private void CreateComps(IAbstractViewModel vm)
        {
            DataContext = vm;

            this.AddPainel(new AbstractScrollViewer());

            var source = new AbstractSource(vm, nameof(vm.Filtro));

            vm.ElementType
                .GetMetadata()
                .GetCamposIgnore()
                .ForEach(campo =>
                {
                    this.AddCampo(source, campo, AbstractCampoTipo.Intervalo);
                });
        }
    }
}