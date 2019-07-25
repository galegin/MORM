using MORM.Apresentacao.ViewsModel;
using MORM.Apresentacao.Comps;
using System.Windows;

namespace MORM.Apresentacao.Views
{
    public class AbstractView : AbstractUserControl
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
        public AbstractView(IAbstractViewModel<TModel> vm) : base(vm)
        {
        }
        #endregion
    }
}