using System.Configuration;
using MORM.Utilidade.Utils;

namespace MORM.Repositorio.Oracle
{
    //-- galeg - 05/05/2018 21:09:58
    public class OracleHelperAmbiente
    {
        private static string ORACLE_HOME = ConfigurationManager.AppSettings[nameof(ORACLE_HOME)] ?? string.Empty;
        private static string TNS_ADMIN = ConfigurationManager.AppSettings[nameof(TNS_ADMIN)] ?? string.Empty;

        static OracleHelperAmbiente()
        {
            SetarVariavelAmbiente();
        }

        public static void SetarVariavelAmbiente()
        {
            VariavelAmbiente.SetarAppSetting(nameof(ORACLE_HOME), ORACLE_HOME);
            VariavelAmbiente.SetarAppSetting(nameof(TNS_ADMIN), TNS_ADMIN);
        }
    }
}