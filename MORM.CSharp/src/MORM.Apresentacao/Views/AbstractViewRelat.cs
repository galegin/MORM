using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Views
{
    public class AbstractViewRelat : AbstractView
    {
        #region construtores
        public AbstractViewRelat(IAbstractViewModelRelat vm) : base(vm)
        {
        }
        #endregion
    }
}