using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace MORM.Utilidade.Utils
{
    //-- galeg - 01/05/2018 16:50:34
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

        private static string _arqLog;
        public static string ArqLog
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_arqLog))
                    _arqLog = Path.Combine(GetDirLog(), PrgLog + "." + DateTime.Today.ToString("yyyy.MM.dd") + ".xml");
                return _arqLog;
            }

            set
            {
                _arqLog = value;
            }
        }

        protected enum TipoLog
        {
            Debug,
            Info,
            Erro
        }

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
        }

        public static void Debug(string metodo, string message)
        {
            if (_inDebug)
                Log(TipoLog.Debug, metodo, message);
        }

        public static void Erro(string metodo, string message)
        {
            Log(TipoLog.Erro, metodo, message);
        }

        public static void Info(string metodo, string message)
        {
            Log(TipoLog.Info, metodo, message);
        }
    }
}