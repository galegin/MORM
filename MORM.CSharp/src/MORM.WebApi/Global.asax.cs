using MORM.Aplicacao.App_Start;
//using MORM.Repositorio.Context;
using MORM.WebApi.App_Start;
using System.Web.Http;
using System.Web.Mvc;

namespace MORM.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new WebApiLogHandler());
            //AbstractDataContext.SetarConnectionFactory();
        }
    }
}