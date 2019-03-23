using MORM.Utils.Classes;
using System;

namespace MORM.WebApi.Controllers
{
    public class MessageHandler
    {
        public class ResponseObject
        {
            public object Conteudo { get; set; }

            public string Mensagem { get; set; }
        }

        public static ResponseObject CreateMessage(string mensagem = "", object conteudo = null)
        {
            return new ResponseObject { Conteudo = conteudo, Mensagem = mensagem };
        }

        public static ResponseObject CreateMessage(Exception ex)
        {
            var message = $"Message: {ex.Message} / StackTrace: {ex.StackTrace}";

            Logger.ErroMensagem(message);

            return CreateMessage(message);
        }
    }
}