using System;

namespace MORM.CrossCutting
{
    public class InicializacaoApp
    {
        #region Variaveis
        private const string _isTrue = "true";
        private const string _isFalse = "false";
        private static string RunKey = RegistryExtensions.RunKey;
        private static string AppName = RegistryExtensions.AppName;
        private static string AppPath = RegistryExtensions.AppPath;
        private static bool _isInicializacao;
        #endregion

        #region propriedades
        public static bool IsInicializacao
        {
            get => GetInicializacao();
            set => SetInicializacao(value);
        }
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
        private static bool GetInicializacao()
        {
            var isInicializacaoAtiva = ConfigurationManagerApp.GetAppSettings(nameof(_isInicializacao)) as string ?? _isFalse;
            _isInicializacao = isInicializacaoAtiva.Equals(_isTrue);
            return _isInicializacao;
        }
        private static void SetInicializacao(bool isInicializacaoAtiva)
        {
            _isInicializacao = isInicializacaoAtiva;
            ConfigurationManagerApp.AddOrUpdateAppSettings(nameof(_isInicializacao), _isTrue);
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
                        RegistryExtensions.SetValue(AppName, AppPath, RunKey);
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
                Logger.Erro("Erro inicializacao aplicativo", ex: ex);
            }
        }
        #endregion

        #endregion
    }
}