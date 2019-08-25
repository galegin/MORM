using MORM.Apresentacao.Comps;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Voltar Inicio")]
    public class VoltarTelaInicio : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            TelaUtils.Instance.VoltarTelaInicio();
        }
    }
}