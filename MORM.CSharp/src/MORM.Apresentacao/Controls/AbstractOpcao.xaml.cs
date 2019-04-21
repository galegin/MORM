using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractOpcao : AbstractUserControl
    {
        public AbstractOpcao()
        {
            InitializeComponent();
        }
    }

    public partial class AbstractOpcao<TModel> : AbstractOpcao
    {
        public AbstractOpcao(TModel model) : base()
        {
            DataContext = new AbstractOpcaoViewModel<TModel>(model);
        }
    }
}