using System.Security.Cryptography;
using System.Text;

namespace MORM.Utilidade.Extensoes
{
    //-- galeg - 31/03/2018 12:16:16
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
    }
}