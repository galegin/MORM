using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractOpcao : AbstractUserControlNotify
    {
        public AbstractOpcao(object model)
        {
            InitializeComponent();
            DataContext = new AbstractOpcaoViewModel(model);
        }
    }
}