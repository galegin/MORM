using System;
using System.Configuration;

namespace MORM.CrossCutting
{
    public class Token
    {
        private static string _chave = 
            ConfigurationManager.AppSettings[nameof(_chave)] ?? "AQ@sw3DE$fr5GT*";

        public Ambiente Ambiente { get; set; }
        public int Expiracao { get; set; }

        public Token(bool expirar)
        {
            Expiracao = (int)(expirar ? DateTime.UtcNow.AddDays(1) : DateTime.UtcNow.AddYears(20))
                .Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public Token(Ambiente ambiente, bool expirar = false) : this(expirar)
        {
            Ambiente = ambiente;
        }

        public Token() : this(true)
        {
        }

        public string GetToken()
        {
            var serializer = JsonExtensions.GetJson(this);
            return CriptoExtensions.Encrypt(serializer, _chave);
        }

        public static Token Autenticar(string token)
        {
            try
            {
                var decoder = CriptoExtensions.Decrypt(token, _chave);
                return JsonExtensions.GetObjectFromJson<Token>(decoder).IsValid();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public static class TokenExtensions
    {
        private const string _tokenExpirado = "Token expirado";

        public static Token IsValid(this Token token)
        {
            var expiracao = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            Check.That(expiracao > token.Expiracao, nameof(token), _tokenExpirado);
            return token;
        }
    }
}