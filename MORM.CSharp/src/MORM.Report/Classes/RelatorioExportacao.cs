using MORM.Report.Extensoes;
using MORM.Report.Tipagens;
using System.IO;

namespace MORM.Report.Classes
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