using MORM.Apresentacao.Comps;

namespace MORM.Apresentacao.Commands.Tela
{
    public class FecharTela : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            TelaUtils.Instance.MainWindow.FecharTela();
        }
    }
}