using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Controls.ViewsModel
{
    public class AbstractOpcaoViewModel<TFiltro, TModel> : AbstractViewModel<TFiltro, TModel>
        where TFiltro : class
        where TModel : class
    {
    }
}