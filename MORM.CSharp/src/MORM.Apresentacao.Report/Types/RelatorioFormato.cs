using System.Collections.Generic;
using System.Linq;

namespace MORM.Apresentacao.Report
{
    public enum RelatorioFormato
    {
        Csv,
        Html,
        Tbl,
        Txt,
        Xml
    }

    public static class RelatorioFormatoExtensions
    {
        public static bool IsAlinhado(this RelatorioFormato formato)
        {
            var listaDeFormato = new RelatorioFormato[]
            {
                RelatorioFormato.Tbl,
                RelatorioFormato.Txt,
            };

            return listaDeFormato.Contains(formato);
        }

        public static bool IsLinhaEmBranco(this RelatorioFormato formato)
        {
            var listaDeFormato = new RelatorioFormato[]
            {
                RelatorioFormato.Tbl,
            };

            return listaDeFormato.Contains(formato);
        }

        public static bool IsLinhaTracejada(this RelatorioFormato formato)
        {
            var listaDeFormato = new RelatorioFormato[]
            {
                RelatorioFormato.Tbl,
            };

            return listaDeFormato.Contains(formato);
        }

        private static Dictionary<RelatorioFormato, IRelatorioDelimitador> _listaDemilitador =
            new Dictionary<RelatorioFormato, IRelatorioDelimitador>
            {
                { RelatorioFormato.Csv, new RelatorioDelimitador("", ";", "", " / ", "", "") },
                { RelatorioFormato.Html, new RelatorioDelimitador("<table><td>", "</td><td>", "</td></table>", " / ", null, null) },
                { RelatorioFormato.Tbl, new RelatorioDelimitador("| ", " | ", " |", " / ", "-", " ") },
                { RelatorioFormato.Txt, new RelatorioDelimitador("", " ", "", "", "", "") },
                { RelatorioFormato.Xml, new RelatorioDelimitador("<reg ", " ", " />", " / ", "", "") },
            };

        public static IRelatorioDelimitador GetDelimitador(this RelatorioFormato formato)
        {
            return _listaDemilitador[formato];
        }
    }
}