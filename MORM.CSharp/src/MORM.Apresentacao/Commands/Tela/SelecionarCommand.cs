using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Selecionar")]
    public class SelecionarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            vm.SelecionarLista();
        }
    }
}