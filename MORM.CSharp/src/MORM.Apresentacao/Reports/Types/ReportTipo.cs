using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao.Reports
{
    public enum ReportTipo
    {
        [Description("1. Visualizar apenas")]
        VisualizarApenas,
        [Description("2. Visualizar impressão")]
        VisualizarImpressao,
        [Description("3. Enviar para impressora")]
        EnviarParaImpressora,
        [Description("4. Enviar por email")]
        EnviarPorEmail,
        [Description("5. Exportar para arquivo")]
        ExportarParaArquivo,
    }

    public static class ReportTipoExtensions
    {
        public static bool IsVisualizar(this ReportTipo tipo) =>
            tipo.In(ReportTipo.VisualizarApenas, ReportTipo.VisualizarImpressao);
        public static bool IsVisualizarApenas(this ReportTipo tipo) =>
            tipo.In(ReportTipo.VisualizarApenas);
        public static bool IsImpressora(this ReportTipo tipo) =>
            tipo.In(ReportTipo.EnviarParaImpressora);
        public static bool IsArquivo(this ReportTipo tipo) => 
            tipo.In(ReportTipo.ExportarParaArquivo);
        public static bool IsEmail(this ReportTipo tipo) =>
            tipo.In(ReportTipo.EnviarPorEmail);
    }
}