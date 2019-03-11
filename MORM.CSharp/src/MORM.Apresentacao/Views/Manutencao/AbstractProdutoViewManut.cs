using MORM.Apresentacao.ViewModels.Manutencao;

namespace MORM.Apresentacao.Views.Manutencao
{
    public class AbstractProdutoViewManut : AbstractViewManut, IAbstractProdutoViewManut
    {
        public AbstractProdutoViewManut(IAbstractProdutoViewModel abstractViewModel) : base(abstractViewModel)
        {
        }
    }
}