using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class CancelarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            if (!vm.IsExibirCancelar)
                return;
            vm.CancelarTela();
        }
    }
}