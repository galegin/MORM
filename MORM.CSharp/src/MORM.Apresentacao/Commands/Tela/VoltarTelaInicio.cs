using MORM.Apresentacao.Comps;

namespace MORM.Apresentacao.Commands.Tela
{
    public class VoltarTelaInicio : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            TelaUtils.Instance.VoltarTelaInicio();
        }
    }
}