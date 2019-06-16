using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/TipoVariacaoMotivo")]
    public class TipoVariacaoMotivoController : AbstractController<TipoVariacaoMotivo>
    {
        public TipoVariacaoMotivoController(ITipoVariacaoMotivoApiService tipoVariacaoMotivoApiService) : base(tipoVariacaoMotivoApiService)
        {
        }
    }
}