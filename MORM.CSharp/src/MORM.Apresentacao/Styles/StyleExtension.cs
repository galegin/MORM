using System;
using System.Configuration;
using System.IO;
using System.Windows;

namespace MORM.Apresentacao.Styles
{
    public static class StyleExtension
    {
        private static string _nomeStyle = ConfigurationManager.AppSettings[nameof(_nomeStyle)] ?? "Default";

        public static void AddTheme(this Application application)
        {
            var fileName = $"{Environment.CurrentDirectory}\\Styles\\{_nomeStyle}\\AbstractStyle.xaml";
            if (!File.Exists(fileName))
                return;

            var source = new Uri(fileName, UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary() { Source = source };
            application.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        public static void AddLocal(this Application application)
        {
            var listaPath = new []
            {
                "/WPF.Bootstrap;component/Themes/Default.xaml"
            };

            foreach (var path in listaPath)
            {
                var source = new Uri(path, UriKind.Relative);
                var resourceDictionary = new ResourceDictionary() { Source = source };
                application.Resources.MergedDictionaries.Add(resourceDictionary);
            }
        }
    }
}