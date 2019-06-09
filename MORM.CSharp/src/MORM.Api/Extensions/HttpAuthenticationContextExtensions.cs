using MORM.Api.App_Start;
using System.Web.Http.Filters;

namespace MORM.Api.Extensions
{
    public static class HttpAuthenticationContextExtensions
    {
        public static Token GetToken(this HttpAuthenticationContext context)
        {
            return context.Request.GetToken();
        }
    }
}