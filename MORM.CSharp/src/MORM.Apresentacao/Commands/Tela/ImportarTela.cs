using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ImportarTela<TEntrada> : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractOpcaoViewModel<TEntrada>;
            var connector = new AbstractImportarConnector<TEntrada>();
            connector.Executar(vm.Model);
        }
    }
}