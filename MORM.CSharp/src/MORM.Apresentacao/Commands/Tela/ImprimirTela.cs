using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Reports;
using MORM.Apresentacao.ViewsModel;
using MORM.CrossCutting;
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

            var report = AbstractReport.GetReport();
            if (report == null)
                return;

            var conteudo = connector.Executar(vm.ObjModel, filtro: report) as string;
            if (string.IsNullOrWhiteSpace(conteudo))
                return;

            DialogsMessages.RelatorioGeradoComSucesso.GetMensagem();
        }
    }
}