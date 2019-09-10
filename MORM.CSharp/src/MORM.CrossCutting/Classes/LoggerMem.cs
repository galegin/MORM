using System.Collections.Generic;

namespace MORM.CrossCutting
{
    public class LoggerMem
    {
        private static IList<string> _listaDeMensagem = new List<string>();
        private static int _qtdeLinhaBuffer = 1000;

        public static void AddMensagem(string mensagem)
        {
            _listaDeMensagem.Insert(0, mensagem);

            if (_listaDeMensagem.Count > _qtdeLinhaBuffer)
                for (int i = _listaDeMensagem.Count; i > _qtdeLinhaBuffer; i--)
                    _listaDeMensagem.RemoveAt(i - 1);
        }

        public static string Mensagem => string.Join("\n", _listaDeMensagem);
    }
}