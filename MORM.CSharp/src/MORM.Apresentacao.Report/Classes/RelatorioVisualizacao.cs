using MORM.Apresentacao.Report.Extensions;
using MORM.Apresentacao.Report.Interfaces;
using MORM.Apresentacao.Report.Types;

namespace MORM.Apresentacao.Report.Classes
{
    public partial class Relatorio
    {
        public void Visualizar(RelatorioFormato? formato = null)
        {
            var formatoVis = this.GetFormato(formato);
            var conteudo = this.GetConteudoExportacao(formatoVis);

            IRelatorioImpressora impressora = new RelatorioImpressora(conteudo,
                nomeImpressora: this.GetNomeImpressora(null));

            impressora.Visualizar();
        }
    }
}