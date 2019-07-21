using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ImportarTela<TEntrada> : AbstractCommand
        where TEntrada : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractViewModel<TEntrada, TEntrada>;
            var connector = new AbstractImportarConnector<TEntrada, TEntrada>();
            connector.Executar(vm.Model);
        }
    }
}