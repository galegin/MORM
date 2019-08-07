using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class IncluirTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            if (!vm.IsExibirIncluir)
                return;
            var connector = new AbstractIncluirConnector<TModel>();
            connector.Executar(vm.oModel);
        }
    }
}