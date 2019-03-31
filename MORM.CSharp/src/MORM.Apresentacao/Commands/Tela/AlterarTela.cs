using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class AlterarTela : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractOpcaoViewModel;
            var connector = new AbstractAlterarConnector();
            connector.Executar(vm.Model);
        }
    }
}