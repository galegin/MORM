using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ConfirmarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            if (!vm.IsExibirConfirmar)
                return;
            vm.ConfirmarTela();
        }
    }
}