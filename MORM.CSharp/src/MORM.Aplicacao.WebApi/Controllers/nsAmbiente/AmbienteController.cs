using MORM.Aplicacao.Config;
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
            return Response(TipoPermissao.Validar, () => {
                var retorno = _ambienteService.Validar(dto) as ValidarAmbienteOutModel;
                retorno.Token = new Token(retorno.Ambiente, true).GetToken();
                retorno.Ambiente = null;
                return retorno;
            });
        }
    }
}