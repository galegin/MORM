namespace MORM.Apresentacao
{
    public class AbstractViewModelProc<TModel> : AbstractViewModel<TModel>, IAbstractViewModelProc
        where TModel : class
    {
        #region construtores
        public AbstractViewModelProc() : base()
        {
        }
        #endregion
    }
}