using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class IncluirTela<TEntrada> : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractViewModel<TEntrada>;
            var connector = new AbstractIncluirConnector<TEntrada>();
            connector.Executar(vm.Model);
        }
    }
}