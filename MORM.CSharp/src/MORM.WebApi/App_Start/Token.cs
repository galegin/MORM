using JWT; // versao 2.4.2
using JWT.Algorithms;
using JWT.Serializers;
using MORM.Dominio.Entidades;
using System;
using System.Web.Configuration;

namespace MORM.WebApi.App_Start
{
    public class Token
    {
        private static string Chave = WebConfigurationManager.AppSettings[nameof(Chave)] ?? "info2143";

        public Ambiente Ambiente { get; set; }

        public Token(bool expirar)
        {
            //if (expirar)
            //    _expiracao = (int)DateTime.UtcNow.AddDays(1).Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            //else
            //    _expiracao = (int)DateTime.UtcNow.AddYears(20).Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
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
            var serializer = new JsonNetSerializer();
            var urlEncoder = new JwtBase64UrlEncoder();
            var encoder = new JwtEncoder(new HMACSHA256Algorithm(), serializer, urlEncoder);
            return encoder.Encode(this, Chave);
        }

        public static Token Autenticar(string token)
        {
            try
            {
                var serializer = new JsonNetSerializer();
                var urlEncoder = new JwtBase64UrlEncoder();
                var decoder = new JwtDecoder(serializer, null, urlEncoder);
                return decoder.DecodeToObject<Token>(token, Chave, verify: false);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}