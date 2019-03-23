using MORM.Utils.Excecoes;
using MORM.Utils.Classes;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;

namespace MORM.Apresentacao.Comps
{
    public partial class AbstractApplication : Application
    {
        public AbstractApplication()
        {
            DispatcherUnhandledException += Application_DispatcherUnhandledException;
            Startup += OnStartup;
        }

        public static void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var messageBoxAction =
                e.Exception is ExceptionDebug ? new Action(() => Logger.DebugException(e.Exception)) :
                e.Exception is ExceptionInfo ? new Action(() => Logger.InfoException(e.Exception)) :
                new Action(() => Logger.ErroException(e.Exception));

            messageBoxAction?.Invoke();

            var messageBoxDescription =
                e.Exception is ExceptionDebug ? "Debug" :
                e.Exception is ExceptionInfo ? "Informacao" : 
                "Erro";

            var messageBoxImage =
                e.Exception is ExceptionDebug ? MessageBoxImage.Warning :
                e.Exception is ExceptionInfo ? MessageBoxImage.Information : 
                MessageBoxImage.Error;

            MessageBox.Show(e.Exception.Message, messageBoxDescription, MessageBoxButton.OK, messageBoxImage);

            e.Handled = true;
        }

        public static void OnStartup(object sender, StartupEventArgs e)
        {
            var cultureInfo = new CultureInfo("pt-BR");

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
               new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }
    }

    public static class AbstractApplicationExtensions
    {
        public static void SetApplication(this Application application)
        {
            application.DispatcherUnhandledException += AbstractApplication.Application_DispatcherUnhandledException;
            application.Startup += AbstractApplication.OnStartup;
        }
    }
}