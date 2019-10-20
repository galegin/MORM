using MORM.CrossCutting;
using MORM.Servico;
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
            return Response(PermissaoTipo.Validar, () => _ambienteService.Validar(dto));
        }
    }
}