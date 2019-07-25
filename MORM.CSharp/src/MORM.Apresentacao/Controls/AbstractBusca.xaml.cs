using MORM.Apresentacao.Comps;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractBusca : AbstractUserControl
    {
        public AbstractBusca()
        {
            InitializeComponent();
        }

        public AbstractBusca(IAbstractViewModel vm) : this()
        {
            DataContext = vm;
        }
    }
}