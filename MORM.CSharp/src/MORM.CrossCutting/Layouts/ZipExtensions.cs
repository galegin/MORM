using System.IO;
using System.IO.Compression;
using System.Text;

namespace MORM.CrossCutting
{
    public static class ZipExtensions
    {
        #region metodos
        #region metodos publicos
        public static string GetZip(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            var conteudo = ZipStr(value);
            return Encoding.UTF8.GetString(conteudo);
        }
        public static string GetStringFromZip(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            var conteudo = Encoding.UTF8.GetBytes(value);
            return UnZipStr(conteudo);
        }
        #endregion
        #region metodos privados
        private static byte[] ZipStr(string str)
        {
            using (MemoryStream output = new MemoryStream())
            {
                using (DeflateStream gzip =
                  new DeflateStream(output, CompressionMode.Compress))
                {
                    using (StreamWriter writer =
                      new StreamWriter(gzip, System.Text.Encoding.UTF8))
                    {
                        writer.Write(str);
                    }
                }

                return output.ToArray();
            }
        }
        private static string UnZipStr(byte[] input)
        {
            using (MemoryStream inputStream = new MemoryStream(input))
            {
                using (DeflateStream gzip =
                  new DeflateStream(inputStream, CompressionMode.Decompress))
                {
                    using (StreamReader reader =
                      new StreamReader(gzip, System.Text.Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
        #endregion
        #endregion
    }
}