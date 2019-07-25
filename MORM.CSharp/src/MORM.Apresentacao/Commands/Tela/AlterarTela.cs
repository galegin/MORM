using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class AlterarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractOpcaoViewModel<TModel>;
            var connector = new AbstractAlterarConnector<TModel>();
            connector.Executar(vm.Model);
        }
    }
}