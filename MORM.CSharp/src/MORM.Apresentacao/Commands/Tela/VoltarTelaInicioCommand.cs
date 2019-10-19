using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Voltar Inicio")]
    public class VoltarTelaInicioCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            TelaUtils.Instance.VoltarTelaInicio();
        }
    }
}