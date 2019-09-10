using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace MORM.CrossCutting
{
    public static class StringExtensions
    {
        public static string GerarHashMd5(this string input)
        {
            MD5 md5Hash = MD5.Create();
            
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }

        //-- data / hora

        public static DateTime? ObterData(this string str)
        {
            string[] formats = { "d", "dd", "ddMM", "ddMMyy", "ddMMyyyy", "dd/MM", "dd/MM/yy", "dd/MM/yyyy", "yyyyMMdd" };
            DateTime temp;
            if (!DateTime.TryParseExact(str, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
                return null;
            return temp;
        }

        public static DateTime? ObterDataHora(this string str)
        {
            string[] formats = { "ddMMyyHHmmss", "ddMMyyyyHHmmss", "dd/MM/yy HH:mm:ss", "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy HH:mm", "ddMMyy HHmmss" };
            DateTime temp;
            if (!DateTime.TryParseExact(str, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
                return null;
            return temp;
        }

        public static DateTime? ObterDataHoraInv(this string str)
        {
            string[] formats = { "yyMMddHHmmss", "yyyyMMddHHmmss", "yy/MM/dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss", "yyyy/MM/dd HH:mm", "yyMMdd HHmmss" };
            DateTime temp;
            if (!DateTime.TryParseExact(str, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
                return null;
            return temp;
        }

        public static DateTime? ObterDataRef(this string str)
        {
            string[] formats = { "MM", "MMyy", "MMyyyy", "MM/yy", "MM/yyyy" };
            DateTime temp;
            if (!DateTime.TryParseExact(str, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
                return null;
            return temp;
        }

        public static DateTime? ObterDataAno(this string str)
        {
            string[] formats = { "yy", "yyyy" };
            DateTime temp;
            if (!DateTime.TryParseExact(str, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
                return null;
            return temp;
        }

        public static DateTime? ObterHora(this string str)
        {
            string[] formats = { "HHmm", "HHmmss", "HH:mm", "HH:mm:ss" };
            DateTime temp;
            if (!DateTime.TryParseExact(str, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
                return null;
            return temp;
        }

        //-- numero

        public static long? ObterNumero(this string entrada)
        {
            long temp;
            if (!long.TryParse(entrada, NumberStyles.Integer, CultureInfo.CurrentCulture, out temp))
                return null;
            return temp;
        }

        //-- valor

        public static decimal? ObterValor(this string entrada)
        {
            decimal temp;
            if (!decimal.TryParse(entrada, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out temp))
                return null;
            return temp;
        }

        //-- coalesce

        public static string Coalesce(this string str, params string[] pars)
        {
            foreach (var par in pars)
                if (!string.IsNullOrWhiteSpace(par))
                    return par;
            return null;
        }
        
        // var codigo = "1";
        // var descricao = codigo.Decode("1", "EM ANDAMENTO", "NAO INFORMADO");
        // var descricao = codigo.Decode("1", "EM ANDAMENTO", "2", "ATENDIDO", "3", "CANCELADO", "NAO INFORMADO");
        public static string Decode(this string str, params string[] pars)
        {
            var parAnt = string.Empty;
            if (pars.Length < 3 || (pars.Length % 2) == 0)
                throw new Exception("Numero de parametro invalido");
            foreach (var par in pars)
            {
                if (!string.IsNullOrWhiteSpace(parAnt))
                    return par;
                if (str.Equals(par))
                    parAnt = par;
            }
            return pars.Length > 0 ? pars[pars.Length-1] : null;
        }

        public static bool NotEmpty(this string conteudo)
        {
            return !string.IsNullOrWhiteSpace(conteudo);
        }

        public static string AllTrim(this string str)
        {
            while (str.StartsWith(" "))
                str = str.Remove(0, 1);
            while (str.EndsWith(" "))
                str = str.Remove(str.Length - 1, 1);
            while (str.Contains("  "))
                str = str.Replace("  ", " ");
            return str;
        }

        //public static string PriMaiuscula(this string conteudo)
        //{
        //    return
        //        conteudo.Substring(0, 1).ToUpper() +
        //        conteudo.Substring(1).ToLower();
        //}

        public static string PriMaiuscula(this string conteudo)
        {
            var retorno = string.Empty;

            for (int i = 0; i < conteudo.Length; i++)
                if (i == 0 || conteudo[i - 1] == '_')
                    retorno += conteudo[i].ToString().ToUpper();
                else
                    retorno += conteudo[i].ToString().ToLower();

            return retorno;
        }

        public static string RemoveAcento(this string str)
        {
            str = str
                .Replace("[ÂÀÁÄÃ]", "A")
                .Replace("[âãàáä]", "a")
                .Replace("[ÊÈÉË]", "E")
                .Replace("[êèéë]", "e")
                .Replace("[ÎÍÌÏ]", "I")
                .Replace("[îíìï]", "i")
                .Replace("[ÔÕÒÓÖ]", "O")
                .Replace("[ôõòóö]", "o")
                .Replace("[ÛÙÚÜ]", "U")
                .Replace("[ûúùü]", "u")
                .Replace("Ç", "C")
                .Replace("ç", "c")
                .Replace("Ý", "Y")
                .Replace("[ýÿ]", "y")
                .Replace("Ñ", "N")
                .Replace("ñ", "n")
                .Replace("['<>\\|/]", "");
            return str;
        }
    }
}