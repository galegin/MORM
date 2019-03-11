using MORM.Aplicacao.Extensions;
using MORM.Repositorio.Services;
using MORM.Utilidade.Dtos;
using MORM.Utilidade.Tipagens;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MORM.Aplicacao.Controllers
{
    //[RoutePrefix("api/AbstractController")]
    public class AbstractControllerFiltro<TObject, TFiltro> : AbstractController<TObject>, IAbstractControllerFiltro<TObject, TFiltro> 
        where TObject : class
        where TFiltro : class
    {
        public AbstractControllerFiltro(IAbstractApiFiltroService<TObject, TFiltro> abstractApiService) : base(null)
        {
            _abstractApiServiceFiltro = abstractApiService ?? throw new ArgumentNullException(nameof(abstractApiService));
            _abstractApiServiceFiltro.SetAmbiente(Request.GetAmbiente());
            SetarPermissaoApiService();
        }

        public AbstractControllerFiltro()
        {
            _abstractApiServiceFiltro = new AbstractApiFiltroService<TObject, TFiltro>(Request.GetAmbiente());
            SetarPermissaoApiService();
        }

        // service

        protected IAbstractApiFiltroService<TObject, TFiltro> _abstractApiServiceFiltro;

        // metodos

        [HttpPost]
        [Route("Listar")]
        public HttpResponseMessage ListarFiltro(DtoAbstractApiFiltro<TObject, TFiltro>.Listar dto)
        {
            try
            {
                VerificarPermissao(TipoPermissao.Listar);

                return Request.CreateResponse(HttpStatusCode.OK, 
                    MessageHandler.CreateMessage(conteudo: _abstractApiServiceFiltro.Listar(dto)));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }
    }
}