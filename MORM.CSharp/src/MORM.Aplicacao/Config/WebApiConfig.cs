using MORM.CrossCutting;
using System.Web.Http;

namespace MORM.Aplicacao
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Somente Json
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(config.Formatters.JsonFormatter);

            // Ioc
            var container = AbstractContainer.Instance;
            container.AddInstaller();

            config.DependencyResolver = new AbstractDependencyResolver(container);
        }
    }
}