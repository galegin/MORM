using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ExcluirTela : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractOpcaoViewModel;
            var connector = new AbstractExcluirConnector();
            connector.Executar(vm.Model);
            vm.Limpar.Execute(vm);
        }
    }
}