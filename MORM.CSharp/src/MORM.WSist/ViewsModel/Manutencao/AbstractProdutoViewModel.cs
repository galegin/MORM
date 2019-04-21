using MORM.Apresentacao.ViewsModel;
using MORM.WSist.Models.Manutencao;

namespace MORM.WSist.ViewsModel.Manutencao
{
    public class AbstractProdutoViewModel : AbstractViewModel<AbstractProdutoModel>
    {
        #region construtores
        public AbstractProdutoViewModel()
        {
            Model = new AbstractProdutoModel();
        }
        #endregion
    }
}