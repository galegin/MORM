using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ExportarTela<TEntrada> : AbstractCommand
        where TEntrada : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractViewModel<TEntrada, TEntrada>;
            var connector = new AbstractExportarConnector<TEntrada, TEntrada>();
            connector.Executar(vm.Model);
        }
    }
}