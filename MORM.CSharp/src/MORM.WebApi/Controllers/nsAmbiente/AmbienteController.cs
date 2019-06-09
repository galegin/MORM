using MORM.Api.App_Start;
using MORM.Api.Controllers;
using MORM.Dtos.nsAmbiente;
using MORM.Servico.Interfaces.nsAmbiente;
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

        public AmbienteController(IAmbienteService ambienteService) : base()
        {
            _ambienteService = ambienteService;
        }

        [HttpPost]
        [Route("Validar")]
        public HttpResponseMessage Validar(ValidarAmbienteDto.Envio dto)
        {
            try
            {
                var retorno = _ambienteService.Validar(dto);
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