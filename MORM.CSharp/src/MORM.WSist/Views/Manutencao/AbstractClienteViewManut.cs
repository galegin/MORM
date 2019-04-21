using MORM.Apresentacao.Views;
using MORM.WSist.ViewsModel.Manutencao;

namespace MORM.WSist.Views.Manutencao
{
    public class AbstractClienteViewManut : AbstractViewManut, IAbstractClienteViewManut
    {
        public AbstractClienteViewManut()
        {
            CreateCampos(new AbstractClienteViewModel());
        }
    }
}