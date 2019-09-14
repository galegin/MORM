using MORM.Aplicacao.Config;
using MORM.CrossCutting;
using MORM.Dominio;
using MORM.Repositorio;
using MORM.Servico;
using System.Web;
using System.Web.Http;

namespace MORM.Aplicacao.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        static WebApiApplication()
        {
            var container = AbstractContainer.Instance;
            container.AddInstaller();
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new WebApiLogHandler());
        }
    }
}