using MORM.Utilidade.Utils;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MORM.Aplicacao.App_Start
{
    //-- galeg - 29/05/2018 19:26:06
    
    /*
        Global.asax.cs
        
        using ProjetoApi.WebApi.App_Start;
        using System.Web.Http;
        using System.Web.Mvc;

        namespace ProjetoApi.WebApi
        {
            public class WebApiApplication : System.Web.HttpApplication
            {
                protected void Application_Start()
                {
                    AreaRegistration.RegisterAllAreas();
                    GlobalConfiguration.Configure(WebApiConfig.Register);
                    GlobalConfiguration.Configuration.MessageHandlers.Add(new WebApiLogHandler()); <<==
                    DataContext.SetarConnectionFactory();
                }
            }
        }
    */
    
    public class WebApiLogHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            const string METHOD = "WebApiLogHandler.SendAsync";

            var requestBody = await request.Content.ReadAsStringAsync();

            Logger.Debug(METHOD, $"WebApi: {request.RequestUri}, Request: {requestBody}");

            var result = await base.SendAsync(request, cancellationToken);

            if (result.Content != null)
            {
                var responseBody = await result.Content.ReadAsStringAsync();

                if (result.StatusCode == HttpStatusCode.OK)
                    Logger.Debug(METHOD, $"WebApi: {request.RequestUri}, Response: {responseBody}");
                else
                    Logger.Erro(METHOD, $"WebApi: {request.RequestUri}, Response: {responseBody}");
            }

            return result;
        }
    }
}