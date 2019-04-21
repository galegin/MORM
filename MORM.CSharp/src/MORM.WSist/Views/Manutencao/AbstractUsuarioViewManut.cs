using MORM.Apresentacao.Views;
using MORM.WSist.ViewsModel.Manutencao;

namespace MORM.WSist.Views.Manutencao
{
    public class AbstractUsuarioViewManut : AbstractViewManut, IAbstractUsuarioViewManut
    {
        public AbstractUsuarioViewManut()
        {
            CreateCampos(new AbstractUsuarioViewModel());
        }
    }
}