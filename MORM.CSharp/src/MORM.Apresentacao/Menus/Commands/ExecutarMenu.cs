namespace MORM.Apresentacao
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
