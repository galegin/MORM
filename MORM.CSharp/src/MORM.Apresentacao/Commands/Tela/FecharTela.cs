namespace MORM.Apresentacao.Commands.Tela
{
    public class FecharTela : AbstractTelaCommand, IAbstractFecharCommand
    {
        public override void Execute(object parameter)
        {
            CloseWindow(parameter);
        }
    }
}