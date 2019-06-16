using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Pais")]
    public class PaisController : AbstractController<Pais>
    {
        public PaisController(IPaisApiService paisApiService) : base(paisApiService)
        {
        }
    }
}