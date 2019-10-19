using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Confirmar")]
    public class ConfirmarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            vm.ConfirmarTela();
        }
    }
}