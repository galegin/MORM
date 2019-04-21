using MORM.Apresentacao.ViewsModel;
using MORM.WSist.Models.Manutencao;

namespace MORM.WSist.ViewsModel.Manutencao
{
    public class AbstractUsuarioViewModel : AbstractViewModel<AbstractUsuarioModel>
    {
        #region construtores
        public AbstractUsuarioViewModel()
        {
            Model = new AbstractUsuarioModel();
        }
        #endregion
    }
}