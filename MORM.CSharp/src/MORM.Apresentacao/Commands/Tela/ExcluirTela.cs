using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ExcluirTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            if (!vm.IsExibirExcluir)
                return;
            var connector = new AbstractExcluirConnector<TModel>();
            connector.Executar(vm.oModel);
            vm.ClearAll();
        }
    }
}