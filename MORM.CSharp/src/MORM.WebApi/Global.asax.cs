using MORM.Api.App_Start;
using MORM.WebApi.App_Start;
using System.Web.Http;

namespace MORM.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new WebApiLogHandler());
        }
    }
}