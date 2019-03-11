using MORM.Aplicacao.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MORM.Aplicacao.App_Start
{
    public class AuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public AuthenticationAttribute()
        {
        }

        public bool AllowMultiple { get; } = false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                //Token token = Token.Autenticar(context);
                Token token = context.GetToken();
                if (token == null)
                {
                    context.ErrorResult = new AuthenticationFailureResult("Falha de autenticação", context.Request);
                }
                else
                {
                    context.ActionContext.Request.Properties.Add("Ambiente", token.Ambiente);
                }
            });
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
            });
        }
    }
}