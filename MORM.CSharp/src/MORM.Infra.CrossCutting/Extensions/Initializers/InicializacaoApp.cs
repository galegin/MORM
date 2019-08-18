using System;

namespace MORM.Infra.CrossCutting
{
    public class InicializacaoApp
    {
        #region Variaveis
        private static string RunKey = RegistryExtensions.RunKey;
        private static string AppName = RegistryExtensions.AppName;
        private static string AppPath = RegistryExtensions.AppPath;
        #endregion

        #region Metodos

        #region Metodos Publicos
        public static bool IsAtivo()
        {
            return RegistryExtensions.GetValue(AppName, RunKey) != null;
        }
        public static void Ativar()
        {
            SetStartup(true);
        }
        public static void Desativar()
        {
            SetStartup(false);
        }
        #endregion

        #region Metodos Privados
        private static void SetStartup(bool OnOff)
        {
            try
            {
                //Abre o registro
                var value = RegistryExtensions.GetValue(AppName, RunKey);

                //Valida se vai incluir o iniciar com o Windows ou remover
                if (OnOff)//Iniciar
                {
                    if (value == null)
                    {
                        // Add startup reg key
                        RegistryExtensions.SetValue(AppName, RunKey, AppPath);
                    }
                }
                else //Nao iniciar mais
                {
                    // remove startup
                    RegistryExtensions.DeleteValue(AppName, RunKey);
                }
            }
            catch (Exception ex)
            {
                Logger.Erro("Erro inicializar com windows", ex: ex);
            }
        }
        #endregion

        #endregion
    }
}