using MORM.Apresentacao.Comps;
using MORM.Apresentacao.ViewsModel;
using System;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractOpcao : AbstractUserControl
    {
        public AbstractOpcao()
        {
            InitializeComponent();
        }

        public AbstractOpcao(IAbstractViewModel vm) : this()
        {
            DataContext = vm;
        }
    }

    public partial class AbstractOpcao<TViewModel> : AbstractOpcao
        where TViewModel : class
    {
        public AbstractOpcao() : base()
        {
            DataContext = Activator.CreateInstance<TViewModel>();
        }

        public AbstractOpcao(IAbstractViewModel<TViewModel> vm) : base()
        {
            DataContext = vm;
        }
    }
}