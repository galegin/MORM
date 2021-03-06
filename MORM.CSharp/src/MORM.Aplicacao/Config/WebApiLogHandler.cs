﻿using MORM.CrossCutting;
//using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MORM.Aplicacao
{
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
                }
            }
        }
    */
    
    public class WebApiLogHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestBody = await request.Content.ReadAsStringAsync();

            Logger.Debug($"WebApi: {request.RequestUri}, Request: {requestBody}");

            var result = await base.SendAsync(request, cancellationToken);

            if (result.Content != null)
            {
                var responseBody = await result.Content.ReadAsStringAsync();

                if (result.StatusCode == HttpStatusCode.OK)
                    Logger.Debug($"WebApi: {request.RequestUri}, Response: {responseBody}");
                else
                    Logger.Erro($"WebApi: {request.RequestUri}, Response: {responseBody}");
            }

            return result;
        }
    }
}