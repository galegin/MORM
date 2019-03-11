using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Menus.ViewModels;

namespace MORM.Apresentacao.Menus.Commands
{
    public class ExecutarSubMenu : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as SubMenuOpcaoViewModel;
            vm.Executar();
        }
    }
}