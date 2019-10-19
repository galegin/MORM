namespace MORM.Apresentacao
{
    public class SelecionarCampo : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractCampoViewModel;
            vm.SelecionarLista();
        }
    }
}