using System;
using System.IO;

namespace MORM.CrossCutting
{
    public class CaminhoPadrao
    {
        #region Propriedades
        public static string PathPadrao { get; set; }
        #endregion

        #region Construtores
        static CaminhoPadrao()
        {
            PathPadrao = AppDomain.CurrentDomain.BaseDirectory;
        }
        #endregion

        #region Metodos
        public static string GetPathSubPasta(string subPasta = null, string nomeArquivo = null, bool isCreateSubPasta = false, string pastaPadrao = null)
        {
            var retorno = pastaPadrao ?? PathPadrao;

            if (!string.IsNullOrWhiteSpace(subPasta))
            {
                retorno = Path.Combine(retorno, subPasta);
                if (isCreateSubPasta && !Directory.Exists(retorno))
                    Directory.CreateDirectory(retorno);
            }

            if (!string.IsNullOrWhiteSpace(nomeArquivo))
            {
                retorno = Path.Combine(retorno, nomeArquivo);
            }

            return retorno;
        }
        #endregion
    }
}