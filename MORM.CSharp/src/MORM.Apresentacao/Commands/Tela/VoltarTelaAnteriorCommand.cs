using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Voltar")]
    public class VoltarTelaAnteriorCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            TelaUtils.Instance.VoltarTelaAnterior();
        }
    }
}