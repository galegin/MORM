using MORM.Apresentacao.Comps;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class FecharTela : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var closeAction = (parameter as IAbstractViewModel)?.CloseAction;
            if (closeAction != null)
                closeAction.Invoke();
            else
                TelaUtils.Instance.MainWindow.FecharTela();
        }
    }
}