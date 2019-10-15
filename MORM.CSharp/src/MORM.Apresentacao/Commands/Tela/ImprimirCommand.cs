using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Reports;
using MORM.Apresentacao.ViewsModel;
using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Imprimir")]
    public class ImprimirCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = vm.ElementType.GetImprimirConnector();

            var report = AbstractReport.GetReport();
            if (report == null)
                return;

            var conteudo = connector.Imprimir(vm.Model, filtro: report) as string;
            if (string.IsNullOrWhiteSpace(conteudo))
                return;

            DialogsMessages.RelatorioGeradoComSucesso.GetMensagem();
        }
    }
}