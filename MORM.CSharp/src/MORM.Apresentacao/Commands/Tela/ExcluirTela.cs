using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Excluir")]
    public class ExcluirTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            var connector = new AbstractExcluirConnector<TModel>();
            connector.Executar(vm.oModel);
            vm.ClearAll();
        }
    }
}