using Microsoft.AspNet.SignalR;
using MORM.Aplicacao.Config;
using Owin;
using System.Web.Http;

namespace MORM.Aplicacao.RunWebApi
{
    public class SelfHostConfig
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var configuration = new HubConfiguration();
            configuration.EnableJSONP = true;
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            appBuilder.UseWebApi(config);
            appBuilder.MapSignalR(configuration);
        }
    }
}