﻿using MORM.Aplicacao.Config;
using System.Web.Http;

namespace MORM.Aplicacao.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Container = BaseInstaller.Container;
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new WebApiLogHandler());
        }
    }
}