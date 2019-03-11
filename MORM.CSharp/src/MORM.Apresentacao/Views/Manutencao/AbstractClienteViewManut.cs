using MORM.Apresentacao.ViewModels.Manutencao;

namespace MORM.Apresentacao.Views.Manutencao
{
    public class AbstractClienteViewManut : AbstractViewManut, IAbstractClienteViewManut
    {
        public AbstractClienteViewManut(IAbstractClienteViewModel abstractViewModel) : base(abstractViewModel)
        {
        }
    }
}