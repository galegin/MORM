using System.IO;

namespace MORM.Apresentacao.Report
{
    public partial class Relatorio
    {
        public void Enviar(string nomeArquivo = null, RelatorioFormato? formato = null)
        {
            var arquivo = this.GetNomeArquivo(nomeArquivo);
            var formatoExp = this.GetFormato(formato);
            var conteudo = this.GetConteudoExportacao(formatoExp);
            File.WriteAllLines(arquivo, conteudo);

            //IRelatorioImpressora impressora = new RelatorioImpressora(conteudo,
            //    nomeImpressora: this.GetNomeImpressora(null));
            //
            //impressora.Visualizar();
        }
    }
}