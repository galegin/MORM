using Microsoft.Win32;
using System;
using System.IO;

namespace MORM.Infra.CrossCutting
{
    public static class RegistryExtensions
    {
        #region Variaveis
        public static string RunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        public static string AppArquivo = AppDomain.CurrentDomain.FriendlyName;
        public static string AppPasta = AppDomain.CurrentDomain.BaseDirectory;
        public static string AppPath = Path.Combine(AppPasta, AppArquivo);
        public static string AppName = AppArquivo.GetLista('.').GetParte(0);
        public static string AppKey = @"SOFTWARE\" + AppName;
        #endregion

        #region Metodos
        public static object GetValue(string name, string appKey = null)
        {
            object value = null;
            RegistryKey startupKey = Registry.LocalMachine.OpenSubKey(appKey ?? AppKey, true);
            if (startupKey != null)
            {
                value = startupKey.GetValue(name);
                startupKey.Close();
            }
            return value;
        }
        public static void SetValue(string name, object value, string appKey = null)
        {
            RegistryKey startupKey = Registry.LocalMachine.OpenSubKey(appKey ?? AppKey, true);
            if (startupKey == null)
                startupKey = Registry.LocalMachine.CreateSubKey(appKey ?? AppKey);
            startupKey.SetValue(name, value);
            startupKey.Close();
        }
        public static void DeleteValue(string name, string appKey = null)
        {
            RegistryKey startupKey = Registry.LocalMachine.OpenSubKey(appKey ?? AppKey, true);
            if (startupKey != null)
            {
                startupKey.DeleteValue(name, false);
                startupKey.Close();
            }
        }
        #endregion
    }
}