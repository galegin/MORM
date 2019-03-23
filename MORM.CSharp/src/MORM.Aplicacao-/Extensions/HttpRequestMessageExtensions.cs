using MORM.Aplicacao.App_Start;
using MORM.Dominio.Interfaces;
using MORM.Utils.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MORM.Aplicacao.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static Token GetToken(this HttpRequestMessage request)
        {
            IEnumerable<string> headerValues;
            if (!request.Headers.TryGetValues("Token", out headerValues))
                return null;

            Logger.DebugMensagem($"headerValues: {string.Join(" / ", headerValues)}");
            var token = headerValues.FirstOrDefault();

            Logger.DebugMensagem($"Token: {token}");
            return Token.Autenticar(token);
        }

        public static IAmbiente GetAmbiente(this HttpRequestMessage request)
        {
            var ambiente = request.GetToken()?.Ambiente;

            Logger.DebugMensagem($"Ambiente: {ambiente?.Codigo}");
            return ambiente;
        }
    }
}