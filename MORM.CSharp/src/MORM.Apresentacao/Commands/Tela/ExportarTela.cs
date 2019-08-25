using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Exportar")]
    public class ExportarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            var connector = new AbstractExportarConnector<TModel>();
            connector.Executar(vm.oModel);
        }
    }
}