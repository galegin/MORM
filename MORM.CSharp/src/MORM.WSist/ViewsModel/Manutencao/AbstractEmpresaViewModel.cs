using MORM.Apresentacao.ViewsModel;
using MORM.WSist.Models.Manutencao;

namespace MORM.WSist.ViewsModel.Manutencao
{
    public class AbstractEmpresaViewModel : AbstractViewModel<AbstractEmpresaModel>
    {
        #region construtores
        public AbstractEmpresaViewModel()
        {
            Model = new AbstractEmpresaModel();
        }
        #endregion
    }
}