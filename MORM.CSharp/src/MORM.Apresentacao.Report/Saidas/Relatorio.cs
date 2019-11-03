using System;
using System.Collections.Generic;

namespace MORM.Apresentacao.Report
{
    public partial class Relatorio : IRelatorio
    {
        public Relatorio(string titulo, 
            IList<IRelatorioParte> partes, 
            RelatorioSaida? saida = null, 
            RelatorioFormato? formato = null,
            int? largura = null,
            string nomeArquivo = null, 
            string nomeImpressora = null, 
            IRelatorioEmailServidor emailServidor = null, 
            IList<IRelatorioEmail> emails = null)
        {
            Titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
            Partes = partes ?? throw new ArgumentNullException(nameof(partes));
            Saida = saida;
            Formato = formato;
            Largura = largura;
            NomeArquivo = nomeArquivo;
            NomeImpressora = nomeImpressora;
            EmailServidor = emailServidor;
            Emails = emails;
        }

        public string Titulo { get; set; }
        public IList<IRelatorioParte> Partes { get; set; }
        public RelatorioSaida? Saida { get; set; }
        public RelatorioFormato? Formato { get; set; }
        public int? Largura { get; set; }
        public string NomeArquivo { get; set; }
        public string NomeImpressora { get; set; }
        public IRelatorioEmailServidor EmailServidor { get; set; }
        public IList<IRelatorioEmail> Emails { get; set; }
    }
}