using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MORM.CrossCutting
{
    public class AbstractApiConsumer
    {
        public static string SiteInterno { get; private set; }
        public static string TokenInterno { get; private set; }

        public static void SetSiteInterno(string siteInterno)
        {
            SiteInterno = siteInterno;
        }
        public static void SetTokenInterno(string tokenInterno)
        {
            TokenInterno = tokenInterno;
        }
    }

    public class AbstractApiConsumer<TEntrada, TRetorno> : AbstractApiConsumer
        where TEntrada : class
        where TRetorno : class
    {
        private readonly string _site = 
            ConfigurationManager.AppSettings[nameof(_site)] ?? "http://localhost:55275/api/";
        private readonly string _token = 
            ConfigurationManager.AppSettings[nameof(_token)];

        public AbstractApiConsumer(string site = null, string token = null)
        {
            if (site != null)
                _site = site;
            if (token != null)
                _token = token;
        }

        public class ApiRetorno
        {
            public HttpStatusCode StatusCode { get; set; }
            public TRetorno Conteudo { get; set; }
            public string CodigoMensagem { get; set; }
            public string Mensagem { get; set; }
        }

        public string GetSite(string site = null) => 
            "".Coalesce(site, _site, SiteInterno);
        public string GetToken(string token = null) => 
            "".Coalesce(token, _token, TokenInterno);

        private HttpClient GetClient()
        {
            var site = GetSite();
            var token = GetToken();

            var client = new HttpClient();
            client.BaseAddress = new Uri(site);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));

            if (!string.IsNullOrWhiteSpace(token))
            {
                client.DefaultRequestHeaders.Add("Token", token);
            }

            return client;
        }

        // http://localhost:52275/api/servico/metodo

        public ApiRetorno Post(TEntrada entity, string url = null)
        {
            url = url ?? entity.GetUrl();

            using (var client = GetClient())
            {
                client.Timeout = TimeSpan.FromHours(1);

                var conteudoJson = entity.GetJsonFromObject();
                var conteudo = new StringContent(conteudoJson, Encoding.UTF8, "application/json");
                var response = client.PostAsync(url, conteudo).Result;

                return HandleHttpStatusCode(response);
            }
        }

        public string GetString(string sitePar = null)
        {
            using (var client = new HttpClient())
            {
                var site = GetSite(sitePar);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));

                var sResponse = client.GetStringAsync(site).Result;
                return sResponse;
            }
        }

        private ApiRetorno HandleHttpStatusCode(HttpResponseMessage response)
        {
            ApiRetorno retorno = null;

            var retornoStr = response.Content.ReadAsStringAsync().Result;

            Logger.Debug(retornoStr);

            try
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.NotFound:
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.Accepted:
                        retorno = retornoStr.GetObjectFromJson<ApiRetorno>();
                        retorno.StatusCode = response.StatusCode;
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Erro("Erro na requisicao", ex: ex);
            }

            return retorno;
        }

        public void SetProtocolo()
        {
            var site = GetSite();
            if (site.StartsWith("https://") || site.Contains(":443"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 |
                    SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }
    }
}

/*
using System;

namespace MORM.Apresentacao.Consumers
{
    public class ApiConsumer<TDto, TRet> where TDto : class where TRet : class
    {
        public TRet Post(TDto dto)
        {
            Dto = dto ?? throw new ArgumentNullException(nameof(dto));
            return Activator.CreateInstance<TRet>();
        }

        public TDto Dto { get; private set; }
        public TRet Conteudo { get; private set; }
        public string Message { get; private set; }
    }
}
*/

/*
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Script.Serialization;

namespace VirtualPDV.Util.Classes
{
    public class ApiConsumerSyncHelper
    {
        public delegate void OnUnauthorized(string retorno);
        public static event OnUnauthorized OnUnauthorizedEvent;

        public static void ExecutarDelegateUnauthorized(string retorno)
        {
            OnUnauthorizedEvent?.Invoke(retorno);
        }
    }

    public class ApiConsumerSync<TDto, TRetorno> where TDto : class where TRetorno : class
    {
        public delegate void OnRetorno(Retorno retorno);

        private const string ApplicationJson = "application/json";
        private readonly string _url;

        public ApiConsumerSync(string url = "", string token = "")
        {
            _url = string.IsNullOrWhiteSpace(url) ? ConfigurationManager.AppSettings["site"] : url;
            TokenInterno = token;
        }

        public class Retorno
        {
            public HttpStatusCode StatusCode { get; set; }
            public string Mensagem { get; set; }
            public TRetorno Conteudo { get; set; }
        }

        public string TokenInterno { get; set; } = "";

        public string Token { get { return InformacaoGlobal.Token; } }

        public Retorno Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Token", string.IsNullOrWhiteSpace(TokenInterno) ? Token : TokenInterno);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJson));

                var url = ApiConsumer<TDto, TRetorno>.GetUrl();
                var response = client.GetAsync(url).Result;

                return HandleHttpStatusCode(response);
            }
        }

        public Retorno Get(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Token", string.IsNullOrWhiteSpace(TokenInterno) ? Token : TokenInterno);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJson));

                var url = $"{ApiConsumer<TDto, TRetorno>.GetUrl()}/{id}";
                var response = client.GetAsync(url).Result;

                return HandleHttpStatusCode(response);
            }
        }

        public Retorno Post(TDto entity)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Token", string.IsNullOrWhiteSpace(TokenInterno) ? Token : TokenInterno);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJson));
                client.Timeout = TimeSpan.FromDays(1);

                var url = ApiConsumer<TDto, TRetorno>.GetUrl();
                var serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
                var conteudo = new StringContent(serializer.Serialize(entity), Encoding.UTF8, ApplicationJson);
                var response = client.PostAsync(url, conteudo).Result;

                return HandleHttpStatusCode(response);
            }
        }

        public Retorno PostComException(TDto entity)
        {
            var apiRetorno = Post(entity);

            if (!string.IsNullOrEmpty(apiRetorno.Mensagem))
                throw new Exception(apiRetorno.Mensagem);

            return apiRetorno;
        }

        public Retorno HandleHttpStatusCode(HttpResponseMessage response)
        {
            Retorno retorno = null;

            var retornoStr = response.Content.ReadAsStringAsync().Result;

            Trace.WriteLine("retornoStr: " + retornoStr);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.Accepted:
                    retorno = JsonConvert.DeserializeObject<Retorno>(retornoStr);
                    retorno.StatusCode = response.StatusCode;
                    break;

                case HttpStatusCode.Unauthorized:
                    retorno = JsonConvert.DeserializeObject<Retorno>(retornoStr);
                    ApiConsumerSyncHelper.ExecutarDelegateUnauthorized(retorno.Mensagem);
                    break;

                default:
                    Logger.Erro("StatusCode: " + response.StatusCode + " / retornoStr: " + retornoStr);
                    throw new Exception(response.StatusCode.ToString());
            }

            return retorno;
        }
    }
} 
*/
