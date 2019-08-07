using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Commands.Tela
{
    public class ExportarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            if (!vm.IsExibirExportar)
                return;
            var connector = new AbstractExportarConnector<TModel>();
            connector.Executar(vm.oModel);
        }
    }
}