using MORM.Aplicacao.Config;
using System.Web.Http.Filters;

namespace MORM.Aplicacao.Extensions
{
    public static class HttpAuthenticationContextExtensions
    {
        public static Token GetToken(this HttpAuthenticationContext context)
        {
            return context.Request.GetToken();
        }
    }
}