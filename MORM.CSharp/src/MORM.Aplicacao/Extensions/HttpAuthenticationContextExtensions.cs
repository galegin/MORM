using MORM.CrossCutting;
using System.Web.Http.Filters;

namespace MORM.Aplicacao
{
    public static class HttpAuthenticationContextExtensions
    {
        public static Token GetToken(this HttpAuthenticationContext context)
        {
            return context.Request.GetToken();
        }
    }
}