namespace MORM.Apresentacao.Commands.Tela
{
    public class VoltarTela : AbstractTelaCommand, IAbstractVoltarCommand
    {
        public override void Execute(object parameter)
        {
            CloseWindow(parameter);
        }
    }
}