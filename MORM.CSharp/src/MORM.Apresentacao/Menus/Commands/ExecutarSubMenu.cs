namespace MORM.Apresentacao
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