using MORM.CrossCutting;
using MORM.Servico.Interfaces;
using MORM.Servico.Models;
using System.Net.Http;
using System.Web.Http;

namespace MORM.Aplicacao.WebApi
{
    [RoutePrefix("api/Ambiente")]
    public class AmbienteController : AbstractController
    {
        private readonly IAmbienteAppService _ambienteService;

        public AmbienteController(IAmbienteAppService ambienteService)
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