using MORM.Dominio.Tipagens;
using MORM.Dtos;
using MORM.Servico.Interfaces;
using MORM.WebApi.Extensions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MORM.WebApi.Controllers
{
    //[RoutePrefix("api/AbstractController")]
    public class AbstractControllerFiltro<TObject, TFiltro> : 
        AbstractController<TObject>, IAbstractControllerFiltro<TObject, TFiltro>
        where TObject : class
        where TFiltro : class
    {
        // variaveis

        protected readonly IAbstractApiFiltroService<TObject, TFiltro> _abstractApiFiltroService;

        // contrutores

        public AbstractControllerFiltro(IAbstractApiFiltroService<TObject, TFiltro> abstractApiFiltroService) : 
            base(abstractApiFiltroService.ApiService)
        {
            _abstractApiFiltroService = abstractApiFiltroService;
            _abstractApiFiltroService.SetAmbiente(Request.GetAmbiente());
            SetarPermissaoApiService();
        }

        // metodos

        [HttpPost]
        [Route("Listar")]
        public HttpResponseMessage ListarFiltro(AbstractApiFiltroDto<TObject, TFiltro>.Listar dto)
        {
            try
            {
                VerificarPermissao(TipoPermissao.Listar);

                return Request.CreateResponse(HttpStatusCode.OK,
                    MessageHandler.CreateMessage(conteudo: _abstractApiFiltroService.Listar(dto)));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }
    }
}