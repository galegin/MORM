using MORM.Apresentacao.Comps;

namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModel : BaseNotifyPropertyChanged
    {
    }

    public class AbstractViewModel<TModel> : AbstractViewModel
    {
        public TModel Model { get; set; }
    }
}