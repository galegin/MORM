using MORM.Apresentacao.ViewsModel;
using MORM.WSist.Models.Manutencao;

namespace MORM.WSist.ViewsModel.Manutencao
{
    public class AbstractTerminalViewModel : AbstractViewModel<AbstractTerminalModel>
    {
        #region construtores
        public AbstractTerminalViewModel()
        {
            Model = new AbstractTerminalModel();
        }
        #endregion
    }
}