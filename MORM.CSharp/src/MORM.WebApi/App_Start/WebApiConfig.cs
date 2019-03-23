//using MORM.Repositorio.Context;
using MORM.WebApi.Ioc;
using System.Web.Http;

namespace MORM.WebApi.App_Start
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

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(config.Formatters.JsonFormatter);

            var container = BaseContainer.Instance;
            config.DependencyResolver = new WindsorDependencyResolver(container);

            //AbstractDataContext.SetarConnectionFactory();
        }
    }
}