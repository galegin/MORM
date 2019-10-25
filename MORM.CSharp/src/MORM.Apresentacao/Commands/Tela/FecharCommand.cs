using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Fechar")]
    public class FecharCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var fecharAction = vm?.FecharAction;
            if (fecharAction != null)
                fecharAction.Invoke();
            else
                TelaUtils.Instance.MainWindow.FecharTela();
        }
    }
}