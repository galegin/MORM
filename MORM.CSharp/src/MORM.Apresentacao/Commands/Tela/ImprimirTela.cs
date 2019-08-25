using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Imprimir")]
    public class ImprimirTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            var connector = new AbstractImprimirConnector<TModel>();
            connector.Executar(vm.oModel);
        }
    }
}