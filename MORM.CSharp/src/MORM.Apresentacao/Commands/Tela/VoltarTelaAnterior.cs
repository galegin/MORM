using MORM.Apresentacao.Comps;

namespace MORM.Apresentacao.Commands.Tela
{
    public class VoltarTelaAnterior : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            TelaUtils.Instance.VoltarTelaAnterior();
        }
    }
}