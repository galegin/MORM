using MORM.CrossCutting;

namespace MORM.Apresentacao
{
    public partial class AbstractManut : AbstractUserControl
    {
        public AbstractManut()
        {
            InitializeComponent();
        }

        public AbstractManut(IAbstractViewModel vm) : this()
        {
            CreateComps(vm);
        }

        private void CreateComps(IAbstractViewModel vm)
        {
            DataContext = vm;

            this.AddPainel(new AbstractScrollViewer());

            var source = new AbstractSource(vm, nameof(vm.Model));

            vm.ElementType
                .GetMetadata()
                .GetCamposIgnore()
                .ForEach(campo =>
                {
                    this.AddCampo(source, campo, AbstractCampoTipo.Individual);
                });
        }
    }
}