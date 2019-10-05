using MORM.Apresentacao.Comps;
using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Fechar")]
    public class FecharCommand : AbstractCommand
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