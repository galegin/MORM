using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;
using MORM.Dominio.Extensions;

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
            vm.Model.CloneInstancePropOrFieldAll(retorno);
        }
    }
}