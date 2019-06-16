using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/TipoVariacao")]
    public class TipoVariacaoController : AbstractController<TipoVariacao>
    {
        public TipoVariacaoController(ITipoVariacaoApiService tipoVariacaoApiService) : base(tipoVariacaoApiService)
        {
        }
    }
}