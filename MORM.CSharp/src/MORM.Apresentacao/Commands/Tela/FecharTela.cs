using MORM.Apresentacao.Comps;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class FecharTela : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var closeAction = vm?.CloseAction;
            if (closeAction != null)
                closeAction.Invoke();
            else
                TelaUtils.Instance.MainWindow.FecharTela();
        }
    }
}