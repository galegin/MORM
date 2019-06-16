using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/RegraFiscal")]
    public class RegraFiscalController : AbstractController<RegraFiscal>
    {
        public RegraFiscalController(IRegraFiscalApiService regraFiscalApiService) : base(regraFiscalApiService)
        {
        }
    }
}