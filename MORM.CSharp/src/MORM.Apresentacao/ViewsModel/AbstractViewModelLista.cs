namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModelLista<TModel> : AbstractViewModel<TModel>, IAbstractViewModelLista
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