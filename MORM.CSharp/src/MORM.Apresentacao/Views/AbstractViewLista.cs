using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Views
{
    public class AbstractViewLista : AbstractView
    {
        #region construtores
        public AbstractViewLista(IAbstractViewModelLista vm) : base(vm)
        {
        }
        #endregion
    }

    public class AbstractViewLista<TModel> : AbstractViewLista
    {
        #region construtores
        public AbstractViewLista() : base(null)
        {
        }
        #endregion
    }
}