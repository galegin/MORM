using MORM.Aplicacao.Controllers;
using MORM.Dominio.Tipagens;
using MORM.Servico.Interfaces;
using MORM.Servico.Models;
using System.Net.Http;
using System.Web.Http;

namespace MORM.Aplicacao.WebApi.Controllers
{
    [RoutePrefix("api/Ambiente")]
    public class AmbienteController : AbstractController
    {
        private readonly IAmbienteAppService _ambienteService;

        public AmbienteController(IAmbienteAppService ambienteService) : base()
        {
            _ambienteService = ambienteService;
        }

        [HttpPost]
        [Route("Validar")]
        public HttpResponseMessage Validar(ValidarAmbienteInModel dto)
        {
            return Response(TipoPermissao.Validar, () => _ambienteService.Validar(dto));
        }
    }
}