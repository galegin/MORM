namespace MORM.Apresentacao.ViewsModel
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