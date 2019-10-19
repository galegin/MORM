namespace MORM.Apresentacao
{
    public class AbstractViewModelLista<TModel> : AbstractViewModel<TModel>, IAbstractViewModel
        where TModel : class
    {
        #region construtores
        public AbstractViewModelLista() : base()
        {
        }
        #endregion
    }
}