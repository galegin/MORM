using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class AlterarTela<TEntrada> : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractOpcaoViewModel<TEntrada>;
            var connector = new AbstractAlterarConnector<TEntrada>();
            connector.Executar(vm.Model);
        }
    }
}