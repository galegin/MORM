using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class IncluirTela : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractOpcaoViewModel;
            var connector = new AbstractIncluirConnector();
            connector.Executar(vm.Model);
        }
    }
}