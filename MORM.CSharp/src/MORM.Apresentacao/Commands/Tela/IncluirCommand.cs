using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Incluir")]
    public class IncluirCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = vm.ElementType.GetIncluirConnector();
            connector.Incluir(vm.Model);
        }
    }
}