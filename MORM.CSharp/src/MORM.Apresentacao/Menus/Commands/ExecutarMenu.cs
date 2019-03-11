using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Menus.ViewModels;

namespace MORM.Apresentacao.Menus.Commands
{
    public class ExecutarMenu : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as MenuOpcaoViewModel;
            vm.Executar();
        }
    }
}
