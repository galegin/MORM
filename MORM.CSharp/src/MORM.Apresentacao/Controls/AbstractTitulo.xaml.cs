using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Controls
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