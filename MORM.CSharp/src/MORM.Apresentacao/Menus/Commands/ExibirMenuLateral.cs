namespace MORM.Apresentacao
{
    public class ExibirMenuLateral : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as TituloSistemaViewModel;
            vm.SetarIsExibirMenuLateral();
        }
    }
}