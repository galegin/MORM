using JWT; // versao 2.4.2
using JWT.Algorithms;
using JWT.Serializers;
using MORM.Utilidade.Entidades;
using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Web.Configuration;
//using System.Web.Http.Filters;

namespace MORM.Aplicacao.App_Start
{
    /// <summary>
    /// criado por MFGALEGO em 15/05/2018 11:10:41
    /// classe Token.cs
    /// funcao 
    /// </summary>
    public class Token
    {
        //private int _expiracao;
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
            //return JsonWebToken.Encode(this, Chave, JwtHashAlgorithm.HS256);

            var serializer = new JsonNetSerializer();
            var urlEncoder = new JwtBase64UrlEncoder();
            var encoder = new JwtEncoder(new HMACSHA256Algorithm(), serializer, urlEncoder);
            return encoder.Encode(this, Chave);
        }

        //public static Token Autenticar(HttpAuthenticationContext context)
        //{
        //    IEnumerable<string> headerValues;
        //    if (!context.Request.Headers.TryGetValues("Token", out headerValues))
        //        return null;

        //    try
        //    {
        //        //return JsonWebToken.DecodeToObject<Token>(headerValues.First(), Chave, true);

        //        return Autenticar(headerValues.First());
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        public static Token Autenticar(string token)
        {
            try
            {
                //return JsonWebToken.DecodeToObject<Token>(token, Chave, true);

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