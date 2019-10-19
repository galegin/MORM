using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Retornar")]
    public class RetornarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            vm.RetornarModel();
        }
    }
}