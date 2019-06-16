using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Estado")]
    public class EstadoController : AbstractController<Estado>
    {
        public EstadoController(IEstadoApiService estadoApiService) : base(estadoApiService)
        {
        }
    }
}