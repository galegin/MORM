using MORM.WebApi.App_Start;
using System.Web.Http.Filters;

namespace MORM.WebApi.Extensions
{
    public static class HttpAuthenticationContextExtensions
    {
        public static Token GetToken(this HttpAuthenticationContext context)
        {
            return context.Request.GetToken();
        }
    }
}