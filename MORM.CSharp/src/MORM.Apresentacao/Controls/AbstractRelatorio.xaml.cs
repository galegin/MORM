namespace MORM.Apresentacao
{
    public partial class AbstractRelatorio : AbstractUserControl
    {
        public AbstractRelatorio()
        {
            InitializeComponent();
        }

        public AbstractRelatorio(IAbstractViewModel vm, object filtro = null) : this()
        {
            CreateComps(vm);
        }

        private void CreateComps(IAbstractViewModel vm, object filtro = null)
        {
            DataContext = vm;

            // ReportViewer
        }
    }
}