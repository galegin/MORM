using MORM.Apresentacao.Report;
using MORM.CrossCutting;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    [Description("Imprimir")]
    public class ImprimirCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = vm.ElementType.GetImprimirConnector();

            var dataGrid = vm.Grade as DataGrid;
            if (dataGrid == null)
                return;

            var report = AbstractReport.GetReport();
            if (report == null)
                return;

            var dataGridReport = dataGrid.GetRelatorio(
                titulo: "Relatorio de " + vm.GetTitulo(),
                nomeArquivo: report.Arquivo,
                nomeImpressora: report.Impressora
                );

            if (!string.IsNullOrWhiteSpace(report.Email))
                dataGridReport.Emails = new List<IRelatorioEmail> { new RelatorioEmail("usuario", report.Email) };

            switch (report.Tipo)
            {
                case ReportTipo.VisualizarApenas:
                case ReportTipo.VisualizarImpressao:
                    dataGridReport.Visualizar();
                    break;
                case ReportTipo.EnviarParaImpressora:
                    dataGridReport.Imprimir();
                    break;
                case ReportTipo.EnviarPorEmail:
                    dataGridReport.Enviar();
                    break;
                case ReportTipo.ExportarParaArquivo:
                    dataGridReport.Exportar();
                    break;
            }

            //var conteudo = connector.Imprimir(report /*vm.Lista*/) as string;
            //if (string.IsNullOrWhiteSpace(conteudo))
            //    return;

            DialogsMessages.ImpressaoEfetuadaComSucesso.GetMensagem();
        }
    }
}