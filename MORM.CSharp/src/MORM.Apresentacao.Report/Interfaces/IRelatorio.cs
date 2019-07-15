using MORM.Apresentacao.Report.Tipagens;
using System.Collections.Generic;

namespace MORM.Apresentacao.Report.Interfaces
{ 
    public interface IRelatorio
    {
        string Titulo { get; set; }
        IList<IRelatorioParte> Partes { get; set; }
        RelatorioSaida? Saida { get; set; }
        RelatorioFormato? Formato { get; set; }
        int? Largura { get; set; }
        string NomeArquivo { get; set; }
        string NomeImpressora { get; set; }
        IRelatorioEmailServidor EmailServidor { get; set; }
        IList<IRelatorioEmail> Emails { get; set; }
        void Exportar(string nomeArquivo = null, RelatorioFormato? formato = null);
        void Imprimir(string nomeImpressora = null, RelatorioFormato? formato = null);
        void Visualizar(RelatorioFormato? formato = null);
    }
}