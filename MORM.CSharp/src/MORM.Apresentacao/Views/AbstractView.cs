using System.Windows;

namespace MORM.Apresentacao
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
            {
                vm.FecharAction += () => btnFechar_Click(null, null);
                vm.ConfirmarAction += () => btnConfirmar_Click(null, null);
                vm.CancelarAction += () => btnCancelar_Click(null, null);
            }
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