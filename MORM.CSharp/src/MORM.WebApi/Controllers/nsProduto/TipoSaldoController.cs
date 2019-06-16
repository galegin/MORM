using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/TipoSaldo")]
    public class TipoSaldoController : AbstractController<TipoSaldo>
    {
        public TipoSaldoController(ITipoSaldoApiService tipoSaldoApiService) : base(tipoSaldoApiService)
        {
        }
    }
}