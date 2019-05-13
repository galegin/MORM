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

    public partial class AbstractOpcao<TModel> : AbstractOpcao
    {
        public AbstractOpcao() : base()
        {
            DataContext = Activator.CreateInstance<TModel>();
        }

        public AbstractOpcao(IAbstractViewModel<TModel> vm) : base()
        {
            DataContext = vm;
        }
    }
}