using MORM.Apresentacao.Commands.Manutencao;
using MORM.Apresentacao.Models.Manutencao;

namespace MORM.Apresentacao.ViewModels.Manutencao
{
    public class AbstractClienteViewModel : AbstractViewModel<IAbstractClienteModel>, IAbstractClienteViewModel
    {
        public AbstractClienteViewModel(IAbstractClienteModel model, IAbstractClienteManutCommand command) : 
            base(model, command)
        {
        }
    }
}