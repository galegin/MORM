using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Excluir")]
    public class ExcluirCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = new AbstractExcluirConnector<object>();
            connector.Executar(vm.Model);
            vm.ClearAll();
        }
    }
}