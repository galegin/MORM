using MORM.Apresentacao.Views;
using MORM.WSist.ViewsModel.Manutencao;

namespace MORM.WSist.Views.Manutencao
{
    public class AbstractEmpresaViewManut : AbstractViewManut, IAbstractEmpresaViewManut
    {
        public AbstractEmpresaViewManut()
        {
            CreateCampos(new AbstractEmpresaViewModel());
        }
    }
}