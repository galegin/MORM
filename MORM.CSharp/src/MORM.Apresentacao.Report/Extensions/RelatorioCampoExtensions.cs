using MORM.Apresentacao.Report.Interfaces;
using MORM.Apresentacao.Report.Types;
using System;
using System.Globalization;

namespace MORM.Apresentacao.Report.Extensions
{
    public static class RelatorioCampoExtensions
    {
        //-- alinhado

        private static string GetAlinhado(this IRelatorioCampo relatorioCampo, string value)
        {
            var conteudo = value;

            if (conteudo.Length > relatorioCampo.Tamanho)
            {
                return conteudo.Substring(0, relatorioCampo.Tamanho);
            }

            switch (relatorioCampo.Alinhamento)
            {
                case RelatorioAlinhamento.Direita:
                    return conteudo.PadLeft(relatorioCampo.Tamanho, ' ');
                case RelatorioAlinhamento.Centro:
                    var tamanhoDisp = relatorioCampo.Tamanho - value.Length;
                    var tamanhoLeft = tamanhoDisp / 2;
                    var tamanhoRight = tamanhoDisp - tamanhoLeft;
                    return "".PadLeft(tamanhoLeft, ' ') + value + "".PadRight(tamanhoRight, ' ');
                default:
                case RelatorioAlinhamento.Esquerda:
                    return conteudo.PadRight(relatorioCampo.Tamanho, ' ');
                case RelatorioAlinhamento.Justificado:
                    break;
            }

            return string.Empty;
        }

        //-- codigo

        public static string GetCodigo(this IRelatorioCampo relatorioCampo, RelatorioFormato formato)
        {
            if (formato.IsAlinhado())
                return relatorioCampo.GetAlinhado(relatorioCampo.Codigo);
            else
                return relatorioCampo.Codigo;
        }

        //-- descricao

        public static string GetDescicao(this IRelatorioCampo relatorioCampo, RelatorioFormato formato)
        {
            if (formato.IsAlinhado())
                return relatorioCampo.GetAlinhado(relatorioCampo.Descricao);
            else
                return relatorioCampo.Descricao;
        }

        //-- value

        private static string GetValueStr(this IRelatorioCampo relatorioCampo, object value)
        {
            var conteudo = string.Empty;

            var formato = $"N{relatorioCampo.Precisao}"; 

            if (value != null)
            {
                if (value is bool || value is bool?) conteudo = (bool)value ? "T" : "F";
                else if (value is DateTime || value is DateTime?) conteudo = ((DateTime)value).ToString();
                else if (value is long || value is long?) conteudo = ((long)value).ToString();
                else if (value is int || value is int?) conteudo = ((int)value).ToString();
                else if (value is short || value is short?) conteudo = ((short)value).ToString();
                else if (value is decimal || value is decimal?) conteudo = ((decimal)value).ToString(formato, CultureInfo.InvariantCulture);
                else if (value is double || value is double?) conteudo = ((double)value).ToString(formato, CultureInfo.InvariantCulture);
                else if (value is float || value is float?) conteudo = ((float)value).ToString(formato, CultureInfo.InvariantCulture);
                else conteudo = value.ToString();
            }

            return conteudo;
        }

        public static string GetValue(this IRelatorioCampo relatorioCampo, RelatorioFormato formato, object value)
        {
            if (formato.IsAlinhado())
                return relatorioCampo.GetAlinhado(relatorioCampo.GetValueStr(value));
            else
                return relatorioCampo.GetValueStr(value);
        }
    }
}