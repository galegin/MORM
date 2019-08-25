using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class SalvarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            vm.SetarAtualizacao();
            var connector = new AbstractSalvarConnector<TModel>();
            connector.Executar(vm.oModel);
        }
    }
}