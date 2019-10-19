using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Limpar")]
    public class LimparCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            vm.ClearAll();
        }
    }
}