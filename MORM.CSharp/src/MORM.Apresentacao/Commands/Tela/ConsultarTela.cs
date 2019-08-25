using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Views;
using MORM.Apresentacao.ViewsModel;
using MORM.Infra.CrossCutting;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ConsultarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            var connector = new AbstractConsultarConnector<TModel>();
            var retorno = connector.Executar(vm.oModel);
            if (retorno.IsModelChavePreenchida())
                vm.Model.CloneInstancePropOrFieldAll(retorno);
        }
    }
}