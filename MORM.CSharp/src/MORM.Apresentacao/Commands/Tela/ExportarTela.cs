using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ExportarTela : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractOpcaoViewModel;
            var connector = new AbstractExportarConnector();
            connector.Executar(vm.Model);
        }
    }
}