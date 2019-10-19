namespace MORM.Apresentacao
{
    public class AbstractViewProc : AbstractView
    {
        #region construtores
        public AbstractViewProc(IAbstractViewModelProc vm) : base(vm)
        {
        }
        #endregion
    }

    public class AbstractViewProc<TViewModel> : AbstractViewProc
    {
        #region construtores
        public AbstractViewProc() : base(null)
        {
        }
        #endregion
    }
}