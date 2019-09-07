using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

namespace MORM.Infra.CrossCutting
{
    public static class InternetSettingsExtensions
    {
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;
        static bool settingsReturn, refreshReturn;

        /// <summary>
        /// InternetSettingsServico.SetProxy(true, "127.0.0.1:8000")
        /// </summary>
        /// <param name="action">enable / disable</param>
        /// <param name="strProxy">server:port</param>
        public static void SetProxy(bool action, string strProxy)
        {
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);

            if (action == true)
            {
                RegKey.SetValue("ProxyServer", strProxy);
                RegKey.SetValue("ProxyEnable", 1);
            }
            else
            {
                RegKey.SetValue("ProxyEnable", 0);
            }

            settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }
    }
}