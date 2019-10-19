namespace MORM.Apresentacao
{
    public class ExibirSubMenu : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as MenuOpcaoViewModel;
            vm.SetarIsExibirSubMenu();
        }
    }
}