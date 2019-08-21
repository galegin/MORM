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
        public const string TipoDebug = "Debug";
        public const string TipoErro = "Erro";
        public const string TipoInfo = "Info";
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

        public static void Log(string tipo, string message, 
            [CallerMemberName] string metodo = "", string gerador = null, Exception ex = null)
        {
            var data = DateTime.Now;

            var exception = ex?.GetMensagemInnerExpcetion();

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
                Log(TipoDebug, metodo, message, $"FilePath {filePath} ({line})", ex);
        }

        // erro

        public static void Erro(string message,
            [CallerMemberName] string metodo = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int line = 0,
            Exception ex = null)
        {
            if (_inErro)
                Log(TipoErro, metodo, message, $"FilePath {filePath} ({line})", ex);
        }

        // info

        public static void Info(string message,
            [CallerMemberName] string metodo = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int line = 0,
            Exception ex = null)
        {
            if (_inInfo)
                Log(TipoInfo, metodo, message, $"FilePath {filePath} ({line})", ex);
        }
        #endregion
    }
}