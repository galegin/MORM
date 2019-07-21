namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModelLista<TModel, TFiltro> : AbstractViewModel<TModel, TFiltro>, IAbstractViewModel
        where TModel : class
        where TFiltro : class
    {
        #region construtores
        public AbstractViewModelLista() : base()
        {
            IsExibirLimpar = true;
            IsExibirConsultar = true;
            IsExibirExportar = true;
            IsExibirImportar = true;
            IsExibirImprimir = true;
        }
        #endregion
    }
}