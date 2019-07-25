namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModelRelat<TModel> : AbstractViewModel<TModel>, IAbstractViewModelRelat
        where TModel : class
    {
        #region construtores
        public AbstractViewModelRelat() : base()
        {
            IsExibirLimpar = true;
            IsExibirConsultar = true;
        }
        #endregion
    }
}