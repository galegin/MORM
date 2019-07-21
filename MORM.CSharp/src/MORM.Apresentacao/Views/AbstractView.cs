using MORM.Apresentacao.ViewsModel;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
{
    public class AbstractView : UserControl
    {
        #region construtores
        public AbstractView(IAbstractViewModel vm)
        {
            SetDataContext(vm);
        }
        #endregion

        #region metodos
        protected void SetDataContext(IAbstractViewModel vm)
        {
            DataContext = vm;
            if (vm != null)
                vm.CloseAction += OnCloseAction;
        }

        private void OnCloseAction()
        {
            Window.GetWindow(this)?.Close();
        }
        #endregion
    }

    public class AbstractView<TModel> : AbstractView
        where TModel : class
    {
        #region construtores
        public AbstractView(IAbstractViewModel<TModel, object> vm) : base(vm)
        {
        }
        #endregion
    }
}