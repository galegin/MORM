namespace MORM.Apresentacao
{
    public partial class AbstractTitulo : AbstractUserControl
    {
        public AbstractTitulo(string titulo)
        {
            InitializeComponent();
            DataContext = new AbstractTituloViewModel(titulo);
        }
    }
}