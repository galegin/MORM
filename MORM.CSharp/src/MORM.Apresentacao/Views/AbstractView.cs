using MORM.Apresentacao.ViewsModel;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
{
    public class AbstractView : UserControl
    {
        #region construtores
        public AbstractView(IAbstractViewModel vm)
        {
            DataContext = vm;
        }
        #endregion
    }

    public class AbstractView<TModel> : AbstractView
    {
        #region construtores
        public AbstractView(IAbstractViewModel<TModel> vm) : base(vm)
        {
        }
        #endregion
    }
}