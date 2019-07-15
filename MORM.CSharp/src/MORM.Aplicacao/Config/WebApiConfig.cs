using MORM.Aplicacao.Resolver;
using MORM.Dominio.Interfaces;
using System.Web.Http;

namespace MORM.Aplicacao.Config
{
    public static class WebApiConfig
    {
        public static IAbstractContainer Container { get; set; }

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
            config.DependencyResolver = new AbstractDependencyResolver(Container);
        }
    }
}