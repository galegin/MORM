using MORM.Apresentacao.Comps;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Voltar")]
    public class VoltarTelaAnterior : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            TelaUtils.Instance.VoltarTelaAnterior();
        }
    }
}