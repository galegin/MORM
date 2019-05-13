using MORM.Report.Extensoes;
using MORM.Report.Interfaces;
using MORM.Report.Tipagens;

namespace MORM.Report.Classes
{
    public partial class Relatorio
    {
        public void Imprimir(string nomeImpressora = null, RelatorioFormato? formato = null)
        {
            var formatoImp = this.GetFormato(formato);
            var conteudo = this.GetConteudoExportacao(formatoImp);

            IRelatorioImpressora impressora = new RelatorioImpressora(conteudo,
                nomeImpressora: this.GetNomeImpressora(nomeImpressora));

            impressora.Imprimir();
        }
    }
}