using MORM.Apresentacao.Report.Extensions;
using MORM.Apresentacao.Report.Types;
using System.IO;

namespace MORM.Apresentacao.Report.Classes
{
    public partial class Relatorio
    {
        public void Exportar(string nomeArquivo = null, RelatorioFormato? formato = null)
        {
            var arquivo = this.GetNomeArquivo(nomeArquivo);
            var formatoExp = this.GetFormato(formato);
            var conteudo = this.GetConteudoExportacao(formatoExp);
            File.WriteAllLines(arquivo, conteudo);
        }
    }
}