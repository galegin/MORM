using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ExcluirTela<TEntrada> : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractOpcaoViewModel<TEntrada>;
            var connector = new AbstractExcluirConnector<TEntrada>();
            connector.Executar(vm.Model);
            vm.Limpar.ExecuteCommand(vm);
        }
    }
}