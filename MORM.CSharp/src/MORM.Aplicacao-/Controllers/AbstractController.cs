using MORM.Aplicacao.Extensions;
using MORM.Repositorio.Services;
using MORM.Repositorio.Services.nsAmbiente;
using MORM.Dtos;
using MORM.Dominio.Interfaces;
using MORM.Dominio.Tipagens;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MORM.Aplicacao.Controllers
{
    //[RoutePrefix("api/AbstractController")]
    public class AbstractController<TObject> : ApiController, IAbstractController<TObject> where TObject : class
    {
        public AbstractController(IAbstractApiService<TObject> abstractApiService)
        {
            _abstractApiService = abstractApiService ?? throw new ArgumentNullException(nameof(abstractApiService));
            _abstractApiService.SetAmbiente(Request.GetAmbiente());
            SetarPermissaoApiService();
        }

        public AbstractController()
        {
            _abstractApiService = new AbstractApiService<TObject>(Request.GetAmbiente());
            SetarPermissaoApiService();
        }

        // service

        protected IAmbiente Ambiente => _abstractApiService.AbstractRepository.DataContext.Ambiente;

        protected IAbstractApiService<TObject> _abstractApiService;

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
        public HttpResponseMessage Listar(DtoAbstractApi<TObject>.Listar dto)
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
        public HttpResponseMessage Consultar(DtoAbstractApi<TObject>.Consultar dto)
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
        public HttpResponseMessage Incluir(DtoAbstractApi<TObject>.Incluir dto)
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
        [Route("IncluirLista")]
        public HttpResponseMessage IncluirLista(DtoAbstractApi<TObject>.IncluirLista dto)
        {
            try
            {
                VerificarPermissao(TipoPermissao.IncluirLista);

                _abstractApiService.IncluirLista(dto);
                return Request.CreateResponse(HttpStatusCode.OK, MessageHandler.CreateMessage());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }

        [HttpPost]
        [Route("Alterar")]
        public HttpResponseMessage Alterar(DtoAbstractApi<TObject>.Alterar dto)
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
        [Route("AlterarLista")]
        public HttpResponseMessage AlterarLista(DtoAbstractApi<TObject>.AlterarLista dto)
        {
            try
            {
                VerificarPermissao(TipoPermissao.AlterarLista);

                _abstractApiService.AlterarLista(dto);
                return Request.CreateResponse(HttpStatusCode.OK, MessageHandler.CreateMessage());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }

        [HttpPost]
        [Route("Salvar")]
        public HttpResponseMessage Salvar(DtoAbstractApi<TObject>.Salvar dto)
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
        [Route("SalvarLista")]
        public HttpResponseMessage SalvarLista(DtoAbstractApi<TObject>.SalvarLista dto)
        {
            try
            {
                VerificarPermissao(TipoPermissao.SalvarLista);

                _abstractApiService.SalvarLista(dto);
                return Request.CreateResponse(HttpStatusCode.OK, MessageHandler.CreateMessage());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }

        [HttpPost]
        [Route("Excluir")]
        public HttpResponseMessage Excluir(DtoAbstractApi<TObject>.Excluir dto)
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

        [HttpPost]
        [Route("ExcluirLista")]
        public HttpResponseMessage ExcluirLista(DtoAbstractApi<TObject>.ExcluirLista dto)
        {
            try
            {
                VerificarPermissao(TipoPermissao.ExcluirLista);

                _abstractApiService.ExcluirLista(dto);
                return Request.CreateResponse(HttpStatusCode.OK, MessageHandler.CreateMessage());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }
    }
}