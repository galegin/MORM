using MORM.Report.Extensoes;
using MORM.Report.Interfaces;
using MORM.Report.Tipagens;

namespace MORM.Report.Classes
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