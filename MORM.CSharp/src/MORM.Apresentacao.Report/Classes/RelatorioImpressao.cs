using MORM.Apresentacao.Report.Extensions;
using MORM.Apresentacao.Report.Interfaces;
using MORM.Apresentacao.Report.Types;

namespace MORM.Apresentacao.Report.Classes
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