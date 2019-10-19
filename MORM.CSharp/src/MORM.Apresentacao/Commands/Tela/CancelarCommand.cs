using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Cancelar")]
    public class CancelarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            vm.CancelarTela();
        }
    }
}