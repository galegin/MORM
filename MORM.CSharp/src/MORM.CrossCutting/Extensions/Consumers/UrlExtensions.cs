using System.Collections.Generic;
using System.Linq;

namespace MORM.CrossCutting
{
    public static class UrlExtension
    {
        public static string GetUrlAbsolute(this string url)
        {
            var urlRetorno = url
                .Replace("https://", "")
                .Replace("http://", "")
                .Replace("www.", "")
                .Replace(":443", "");

            if (urlRetorno.Contains(":"))
                urlRetorno = urlRetorno.Split(':')[0];
            if (urlRetorno.Contains("/"))
                urlRetorno = urlRetorno.Split('/')[0];

            var urlParte = urlRetorno.Split('.');
            var lstParte = new List<string>();

            var qtde = urlRetorno.EndsWith(".br") ? 3 : 2;

            if (urlParte.Length >= qtde)
                for (var item = 0; item < qtde; item++)
                    lstParte.Add(urlParte[(urlParte.Length - qtde) + item]);
            else
                lstParte = urlParte.ToList();

            return string.Join(".", lstParte);
        }
    }
}