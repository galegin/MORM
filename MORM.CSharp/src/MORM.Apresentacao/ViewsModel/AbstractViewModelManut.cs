namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModelManut<TModel> : AbstractViewModel<TModel>, IAbstractViewModelManut
        where TModel : class
    {
        #region construtores
        public AbstractViewModelManut() : base()
        {
        }
        #endregion
    }
}