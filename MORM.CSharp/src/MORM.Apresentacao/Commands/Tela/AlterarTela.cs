using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class AlterarTela<TEntrada> : AbstractCommand
        where TEntrada : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractOpcaoViewModel<TEntrada, TEntrada>;
            var connector = new AbstractAlterarConnector<TEntrada, TEntrada>();
            connector.Executar(vm.Model);
        }
    }
}