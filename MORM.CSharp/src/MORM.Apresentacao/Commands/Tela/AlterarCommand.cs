using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Alterar")]
    public class AlterarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = vm.ElementType.GetAlterarConnector();
            connector.Alterar(vm.Model);
        }
    }
}