using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;

namespace MORM.Utils.Classes
{
    public class Logger
    {
        public static string PrgLog { get; set; } = "logging";
        public static DateTime DatLog { get; set; } = DateTime.Today;

        private static bool _inDebug =
            ConfigurationManager.AppSettings[nameof(_inDebug)] == "true";

        private static string GetDirLog()
        {
            var _listDirLog = new List<string>
            {
                ConfigurationManager.AppSettings["dirlog"],
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log"),
                "c:\\temp\\",
            };

            foreach (var dirLog in _listDirLog)
                if (!string.IsNullOrWhiteSpace(dirLog) && Directory.Exists(dirLog))
                    return dirLog;

            return "c:\\";
        }

        public static void CreateDirLog()
        {
            var dirLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            if (!Directory.Exists(dirLog))
                Directory.CreateDirectory(dirLog);
        }

        private static string _arqLog;
        public static string ArqLog
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_arqLog))
                    _arqLog = Path.Combine(GetDirLog(), PrgLog + "." + DateTime.Today.ToString("yyyy.MM.dd") + ".xml");
                return _arqLog;
            }
            set { _arqLog = value; }
        }

        protected enum TipoLog
        {
            Debug,
            Info,
            Erro
        }

        // log

        protected static void Log(TipoLog tipo, string metodo, string message)
        {
            // gerar novo arquivo quando virada do dia
            if (DatLog != DateTime.Today)
            {
                _arqLog = null;
                DatLog = DateTime.Today;
            }

            var conteudo =
                "<log>" + "\r\n" +
                "<data>" + DateTime.Now.ToString() + "</data>" + "\r\n" +
                "<tipo>" + tipo.ToString() + "</tipo>" + "\r\n" +
                "<metodo>" + metodo + "</metodo>" + "\r\n" +
                "<message>" + message + "</message>" + "\r\n" +
                "</log>" + "\r\n";

            StreamWriter vWriter = new StreamWriter(ArqLog, true);
            vWriter.WriteLine(conteudo);
            vWriter.Flush();
            vWriter.Close();

            LoggerMem.AddMensagem(conteudo);
        }

        // debug

        public static void Debug(string metodo, string message)
        {
            if (_inDebug)
                Log(TipoLog.Debug, metodo, message);
        }

        public static void DebugMensagem(string message,
            [CallerMemberName] string metodo = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int line = 0)
        {
            if (_inDebug)
                Log(TipoLog.Debug, metodo, $"{message} / FilePath: {filePath} na linha {line}");
        }

        // erro

        public static void Erro(string metodo, string message)
        {
            Log(TipoLog.Erro, metodo, message);
        }

        public static void ErroMensagem(string message,
            [CallerMemberName] string metodo = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int line = 0)
        {
            Log(TipoLog.Erro, metodo, $"{message} / FilePath: {filePath} na linha {line}");
        }

        // info

        public static void Info(string metodo, string message)
        {
            Log(TipoLog.Info, metodo, message);
        }

        public static void InfoMensagem(string message,
            [CallerMemberName] string metodo = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int line = 0)
        {
            Log(TipoLog.Info, metodo, $"{message} / FilePath: {filePath} na linha {line}");
        }

        // exception

        public static void DebugException(Exception ex, string mensagem = null,
            [CallerMemberName] string metodo = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int line = 0)
        {
            Log(TipoLog.Debug, metodo, (!string.IsNullOrWhiteSpace(mensagem) ? $"{mensagem} / " : null) +
                $"Message: {ex.Message} / StackTrace: {ex.StackTrace} / " +
                $"FilePath: {filePath} na linha {line}");
        }

        public static void ErroException(Exception ex, string mensagem = null,
            [CallerMemberName] string metodo = "", 
            [CallerFilePath] string filePath = "", 
            [CallerLineNumber] int line = 0)
        {
            Log(TipoLog.Erro, metodo, (!string.IsNullOrWhiteSpace(mensagem) ? $"{mensagem} / " : null) +
                $"Message: {ex.Message} / StackTrace: {ex.StackTrace} / " +
                $"FilePath: {filePath} na linha {line}");
        }

        public static void InfoException(Exception ex, string mensagem = null,
            [CallerMemberName] string metodo = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int line = 0)
        {
            Log(TipoLog.Info, metodo, (!string.IsNullOrWhiteSpace(mensagem) ? $"{mensagem} / " : null) +
                $"Message: {ex.Message} / StackTrace: {ex.StackTrace} / " +
                $"FilePath: {filePath} na linha {line}");
        }
    }
}