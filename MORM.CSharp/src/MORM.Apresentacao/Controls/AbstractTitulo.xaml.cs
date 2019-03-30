using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractTitulo : AbstractUserControlNotify
    {
        public AbstractTitulo(string titulo)
        {
            InitializeComponent();
            DataContext = new AbstractTituloViewModel(titulo);
        }
    }
}