using System.ComponentModel;

namespace MORM.Apresentacao
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