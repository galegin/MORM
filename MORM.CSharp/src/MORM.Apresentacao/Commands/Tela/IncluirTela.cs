using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class IncluirTela<TEntrada> : AbstractCommand
        where TEntrada : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractViewModel<TEntrada, TEntrada>;
            var connector = new AbstractIncluirConnector<TEntrada, TEntrada>();
            connector.Executar(vm.Model);
        }
    }
}