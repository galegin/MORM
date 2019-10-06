using MORM.CrossCutting;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MORM.Aplicacao
{
    public static class HttpRequestMessageExtensions
    {
        public static Token GetToken(this HttpRequestMessage request)
        {
            IEnumerable<string> headerValues;
            if (!request.Headers.TryGetValues("Token", out headerValues))
                return null;

            Logger.Debug($"headerValues: {string.Join(" / ", headerValues)}");
            var token = headerValues.FirstOrDefault();

            Logger.Debug($"Token: {token}");
            return Token.Autenticar(token);
        }

        public static IAmbiente GetAmbiente(this HttpRequestMessage request)
        {
            var ambiente = request.GetToken()?.Ambiente;

            Logger.Debug($"Ambiente: {ambiente?.Codigo}");
            return ambiente;
        }
    }
}