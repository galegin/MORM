using MORM.Dtos.nsAmbiente;
using MORM.Servico.Interfaces.nsAmbiente;
using MORM.WebApi.App_Start;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MORM.WebApi.Controllers.nsAmbiente
{
    [RoutePrefix("api/Ambiente")]
    public class AmbienteController : ApiController
    {
        private readonly IAmbienteService _ambienteService;

        public AmbienteController(IAmbienteService ambienteService)
        {
            _ambienteService = ambienteService;
        }

        [HttpPost]
        [Route("ValidarAcesso")]
        public HttpResponseMessage ValidarAcesso(AmbienteDto.ValidarAcesso dto)
        {
            try
            {
                var retorno = _ambienteService.ValidarAcesso(dto);
                retorno.Token = new Token(retorno.Ambiente, true).GetToken();
                retorno.Ambiente = null;
                return Request.CreateResponse(HttpStatusCode.OK, MessageHandler.CreateMessage(conteudo: retorno));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }
    }
}