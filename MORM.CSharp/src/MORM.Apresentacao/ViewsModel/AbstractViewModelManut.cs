namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModelManut<TModel> : AbstractViewModel<TModel, object>, IAbstractViewModelManut
        where TModel : class
    {
        #region construtores
        public AbstractViewModelManut() : base()
        {
            IsExibirLimpar = true;
            IsExibirConsultar = true;
            IsExibirIncluir = true;
            IsExibirAlterar = true;
            IsExibirSalvar = true;
            IsExibirExcluir = true;
        }
        #endregion
    }
}