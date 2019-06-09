namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModelProc<TModel> : AbstractViewModel<TModel>, IAbstractViewModelProc
    {
        #region construtores
        public AbstractViewModelProc() : base()
        {
            IsExibirLimpar = true;
            IsExibirConsultar = true;
        }
        #endregion
    }
}