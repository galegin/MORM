using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ImprimirTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractViewModel<TModel>;
            var connector = new AbstractImprimirConnector<TModel>();
            connector.Executar(vm.Model);
        }
    }
}