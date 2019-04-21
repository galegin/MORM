using MORM.Apresentacao.ViewsModel;
using MORM.WSist.Models.Manutencao;

namespace MORM.WSist.ViewsModel.Manutencao
{
    public class AbstractClienteViewModel : AbstractViewModel<AbstractClienteModel>
    {
        #region construtores
        public AbstractClienteViewModel()
        {
            Model = new AbstractClienteModel();
        }
        #endregion
    }
}