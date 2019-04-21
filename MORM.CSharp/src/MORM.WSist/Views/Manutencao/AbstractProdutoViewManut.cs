using MORM.Apresentacao.Views;
using MORM.WSist.ViewsModel.Manutencao;

namespace MORM.WSist.Views.Manutencao
{
    public class AbstractProdutoViewManut : AbstractViewManut, IAbstractProdutoViewManut
    {
        public AbstractProdutoViewManut()
        {
            CreateCampos(new AbstractProdutoViewModel());
        }
    }
}