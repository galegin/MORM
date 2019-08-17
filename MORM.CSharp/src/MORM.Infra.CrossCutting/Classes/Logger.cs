using System;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;

namespace MORM.Infra.CrossCutting
{
    public class Logger
    {
        #region variaveis
        private static readonly object FileLock = new object();
        private static bool _inArqLog;
        private static bool _inDebug;
        private static bool _inErro;
        private static bool _inInfo;
        #endregion

        #region propriedades
        public static string ArquivoLog => $"logging.{DateTime.Now:yyyy-MM-dd}.xml";
        public static string PastaLog => CaminhoPadrao.GetPathSubPasta("log", isCreateSubPasta: true);
        public static string CaminhoLog => Path.Combine(PastaLog, ArquivoLog);
        public static string DadosCabecalho;
        #endregion

        #region Construtores
        static Logger()
        {
            _inArqLog = (ConfigurationManager.AppSettings[nameof(_inArqLog)] ?? "true") == "true";
            _inDebug = (ConfigurationManager.AppSettings[nameof(_inDebug)] ?? "false") == "true";
            _inErro = (ConfigurationManager.AppSettings[nameof(_inErro)] ?? "true") == "true";
            _inInfo = (ConfigurationManager.AppSettings[nameof(_inInfo)] ?? "false") == "true";
        }
        #endregion

        #region metodos

        // log

        protected static void Log(string tipo, string metodo, string message, string gerador, Exception ex = null)
        {
            var data = DateTime.Now;

            var exception = string.Empty;

            while (ex != null)
            {
                exception += (!string.IsNullOrWhiteSpace(exception) ? " / " : null) + 
                    $"{ex.Message} / Trace: {ex.StackTrace}";
                ex = ex.InnerException;
            }

            var mensagemArq =
                "<log>" + "\r\n" +
                "<data>" + data.ToString() + "</data>" + "\r\n" +
                "<tipo>" + tipo + "</tipo>" + "\r\n" +
                "<metodo>" + metodo + "</metodo>" + "\r\n" +
                "<message>" + message + "</message>" + "\r\n" +
                "<gerador>" + gerador + "</gerador>" + "\r\n" +
                "<exception>" + exception + "</exception>" + "\r\n" +
                "</log>" + "\r\n";

            if (_inArqLog)
                try
                {
                    if (!File.Exists(CaminhoLog))
                    {
                        Directory.CreateDirectory(PastaLog);
                        if (!string.IsNullOrWhiteSpace(DadosCabecalho))
                            File.AppendAllText(CaminhoLog, DadosCabecalho);
                    }

                    lock (FileLock)
                        File.AppendAllText(CaminhoLog, mensagemArq);
                }
                catch (Exception exx)
                {
                    System.Diagnostics.Debug.WriteLine(exx);
                }

            var mensagemMem =
                "[ " + data.ToString() + " ]" + "\r\n" +
                "Tipo: " + tipo + " / " + 
                "Metodo: " + metodo + "\r\n" +
                "Message: " + message + "\r\n" ;

            LoggerMem.AddMensagem(mensagemMem);
        }

        // debug

        public static void Debug(string message,
            [CallerMemberName] string metodo = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int line = 0,
            Exception ex = null)
        {
            if (_inDebug)
                Log("Debug", metodo, message, $"FilePath {filePath} ({line})", ex);
        }

        // erro

        public static void Erro(string message,
            [CallerMemberName] string metodo = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int line = 0,
            Exception ex = null)
        {
            if (_inErro)
                Log("Erro", metodo, message, $"FilePath {filePath} ({line})", ex);
        }

        // info

        public static void Info(string message,
            [CallerMemberName] string metodo = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int line = 0,
            Exception ex = null)
        {
            if (_inInfo)
                Log("Info", metodo, message, $"FilePath {filePath} ({line})", ex);
        }
        #endregion
    }
}