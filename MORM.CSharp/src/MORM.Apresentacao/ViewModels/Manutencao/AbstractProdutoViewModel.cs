using MORM.Apresentacao.Commands.Manutencao;
using MORM.Apresentacao.Models.Manutencao;

namespace MORM.Apresentacao.ViewModels.Manutencao
{
    public class AbstractProdutoViewModel : AbstractManutViewModel<IAbstractProdutoModel>, IAbstractProdutoViewModel
    {
        public AbstractProdutoViewModel(IAbstractProdutoModel model, IAbstractProdutoManutCommand command) : 
            base(model, command)
        {
        }
    }
}