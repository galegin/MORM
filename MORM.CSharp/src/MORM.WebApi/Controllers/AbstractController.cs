using MORM.Dtos;
using MORM.Dominio.Interfaces;
using MORM.Dominio.Tipagens;
using MORM.Servico.Interfaces;
using MORM.Servico.Interfaces.nsAmbiente;
using MORM.Servico.Services.nsAmbiente;
using MORM.WebApi.Extensions;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MORM.WebApi.Controllers
{
    //[RoutePrefix("api/AbstractController")]
    public class AbstractController<TObject> : ApiController, IAbstractController<TObject> where TObject : class
    {
        // variaveis

        protected readonly IAbstractApiService<TObject> _abstractApiService;

        // construtores

        public AbstractController(IAbstractApiService<TObject> abstractApiService)
        {
            _abstractApiService = abstractApiService;
            _abstractApiService.SetAmbiente(Request.GetAmbiente());
            SetarPermissaoApiService();
        }

        // service

        protected IAmbiente Ambiente => _abstractApiService.AbstractRepository.DataContext.Ambiente;

        // servico

        private static bool _inVerificarPermissao =
            ConfigurationManager.AppSettings[nameof(_inVerificarPermissao)] == "true";
        private static bool _inGravarLogAcesso =
            ConfigurationManager.AppSettings[nameof(_inGravarLogAcesso)] == "true";

        protected string CodigoServico => GetType().Name.Replace("Controller", "");

        protected IPermissaoService _permissaoService;
        protected ILogAcessoService _logAcessoService;

        protected void SetarPermissaoApiService()
        {
            if (_inVerificarPermissao)
                _permissaoService = new PermissaoService(_abstractApiService.AbstractUnityOfWork);
            if (_inGravarLogAcesso)
                _logAcessoService = new LogAcessoService(_abstractApiService.AbstractUnityOfWork);
        }

        // log acesso

        protected void GravarLogAcesso(TipoPermissao tipoPermissao)
        {
            _logAcessoService?.GravarLog(
                Ambiente.CodigoEmpresa,
                Ambiente.CodigoUsuario,
                CodigoServico,
                tipoPermissao.ToString());
        }

        // permissao

        protected TipoPermissao[] _listaDePermissao = { TipoPermissao.Consultar, TipoPermissao.Incluir };

        protected void VerificarPermissao(TipoPermissao tipoPermissao)
        {
            GravarLogAcesso(tipoPermissao);

            var contemPermissao = _permissaoService?.VerificarPermissao(
                Ambiente.CodigoEmpresa,
                Ambiente.CodigoUsuario,
                CodigoServico,
                tipoPermissao.ToString())
                ??
                _listaDePermissao?.Contains(tipoPermissao)
                ??
                true;

            if (!contemPermissao)
                throw new Exception("Sem permissao para acessar o servico / metodo");
        }

        // metodos

        [HttpPost]
        [Route("Listar")]
        public HttpResponseMessage Listar(AbstractApiDto<TObject>.Listar dto)
        {
            try
            {
                VerificarPermissao(TipoPermissao.Listar);

                return Request.CreateResponse(HttpStatusCode.OK,
                    MessageHandler.CreateMessage(conteudo: _abstractApiService.Listar(dto)));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }

        [HttpPost]
        [Route("Consultar")]
        public HttpResponseMessage Consultar(AbstractApiDto<TObject>.Consultar dto)
        {
            try
            {
                VerificarPermissao(TipoPermissao.Consultar);

                return Request.CreateResponse(HttpStatusCode.OK,
                    MessageHandler.CreateMessage(conteudo: _abstractApiService.Consultar(dto)));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }

        [HttpPost]
        [Route("Incluir")]
        public HttpResponseMessage Incluir(AbstractApiDto<TObject>.Incluir dto)
        {
            try
            {
                VerificarPermissao(TipoPermissao.Incluir);

                _abstractApiService.Incluir(dto);
                return Request.CreateResponse(HttpStatusCode.OK, MessageHandler.CreateMessage());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }

        [HttpPost]
        [Route("Alterar")]
        public HttpResponseMessage Alterar(AbstractApiDto<TObject>.Alterar dto)
        {
            try
            {
                VerificarPermissao(TipoPermissao.Alterar);

                _abstractApiService.Alterar(dto);
                return Request.CreateResponse(HttpStatusCode.OK, MessageHandler.CreateMessage());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }

        [HttpPost]
        [Route("Salvar")]
        public HttpResponseMessage Salvar(AbstractApiDto<TObject>.Salvar dto)
        {
            try
            {
                VerificarPermissao(TipoPermissao.Salvar);

                _abstractApiService.Salvar(dto);
                return Request.CreateResponse(HttpStatusCode.OK, MessageHandler.CreateMessage());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }

        [HttpPost]
        [Route("Excluir")]
        public HttpResponseMessage Excluir(AbstractApiDto<TObject>.Excluir dto)
        {
            try
            {
                VerificarPermissao(TipoPermissao.Excluir);

                _abstractApiService.Excluir(dto);
                return Request.CreateResponse(HttpStatusCode.OK, MessageHandler.CreateMessage());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }
    }
}