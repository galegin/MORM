using MORM.Aplicacao.Extensions;
using MORM.Dominio.Interfaces;
using MORM.Dominio.Tipagens;
using MORM.Servico.Interfaces;
using MORM.Servico.Models;
using MORM.Servico.Services;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MORM.Aplicacao.Controllers
{
    //[RoutePrefix("api/AbstractController")]
    public class AbstractController : ApiController
    {
        #region variaveis
        protected TipoPermissao[] _listaDePermissao = {
            TipoPermissao.Consultar,
            TipoPermissao.Incluir,
            TipoPermissao.Validar };
        #endregion

        #region metodos
        protected virtual void VerificarPermissao(TipoPermissao tipoPermissao)
        {
            var contemPermissao = 
                _listaDePermissao?.Contains(tipoPermissao)
                ??
                true;

            if (!contemPermissao)
                throw new Exception("Sem permissao para acessar o servico / metodo");
        }

        public HttpResponseMessage Response(TipoPermissao tipo, Func<object> funcao)
        {
            try
            {
                VerificarPermissao(tipo);

                return Request.CreateResponse(HttpStatusCode.OK,
                    MessageHandler.CreateMessage(conteudo: funcao.Invoke()));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }
        #endregion
    }

    //[RoutePrefix("api/AbstractController")]
    public class AbstractController<TObject> : AbstractController, IAbstractController<TObject> where TObject : class
    {
        #region variaveis
        protected IAmbiente _ambiente;

        protected readonly IAbstractAppService<TObject> _abstractAppService;

        private static bool _inVerificarPermissao =
            ConfigurationManager.AppSettings[nameof(_inVerificarPermissao)] == "true";
        private static bool _inGravarLogAcesso =
            ConfigurationManager.AppSettings[nameof(_inGravarLogAcesso)] == "true";

        protected string _codigoServico => GetType().Name.Replace("Controller", "");

        protected IPermissaoAppService _permissaoService;
        protected ILogAcessoAppService _logAcessoService;
        #endregion

        #region propriedades
        protected IAmbiente Ambiente => _ambiente;
        #endregion

        #region construtores
        public AbstractController(IAbstractAppService<TObject> abstractAppService) : base()
        {
            _abstractAppService = abstractAppService;
            SetarPermissaoAppService();
        }
        #endregion

        #region metodos
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            _ambiente = controllerContext.Request.GetAmbiente();
            _abstractAppService.SetAmbiente(_ambiente);
            base.Initialize(controllerContext);
        }

        protected void SetarPermissaoAppService()
        {
            if (_inVerificarPermissao)
                _permissaoService = new PermissaoAppService(_abstractAppService.AbstractUnityOfWork);
            if (_inGravarLogAcesso)
                _logAcessoService = new LogAcessoAppService(_abstractAppService.AbstractUnityOfWork);
        }

        protected void GravarLogAcesso(TipoPermissao tipoPermissao)
        {
            var dto = new GravarLogAcessoInModel
            {
                CodigoEmpresa = Ambiente.CodigoEmpresa,
                CodigoUsuario = Ambiente.CodigoUsuario,
                CodigoServico = _codigoServico,
                CodigoMetodo = tipoPermissao.ToString(),
            };

            _logAcessoService?.GravarLog(dto);
        }

        protected override void VerificarPermissao(TipoPermissao tipoPermissao)
        {
            GravarLogAcesso(tipoPermissao);

            var dto = new VerificarPermissaoInModel
            {
                CodigoEmpresa = Ambiente.CodigoEmpresa,
                CodigoUsuario = Ambiente.CodigoUsuario,
                CodigoServico = _codigoServico,
                CodigoMetodo = tipoPermissao.ToString(),
            };

            var contemPermissao = _permissaoService?.VerificarPermissao(dto)
                ??
                _listaDePermissao?.Contains(tipoPermissao)
                ??
                true;

            if (!contemPermissao)
                throw new Exception("Sem permissao para acessar o servico / metodo");
        }

        [HttpPost]
        [Route("Listar")]
        public HttpResponseMessage Listar(TObject filtro)
        {
            return Response(TipoPermissao.Listar, () => _abstractAppService.Listar(filtro));
        }

        [HttpPost]
        [Route("Consultar")]
        public HttpResponseMessage Consultar(TObject filtro)
        {
            return Response(TipoPermissao.Consultar, () => _abstractAppService.Consultar(filtro));
        }

        [HttpPost]
        [Route("Incluir")]
        public HttpResponseMessage Incluir(TObject objeto)
        {
            return Response(TipoPermissao.Incluir, () => _abstractAppService.Incluir(objeto));
        }

        [HttpPost]
        [Route("Alterar")]
        public HttpResponseMessage Alterar(TObject objeto)
        {
            return Response(TipoPermissao.Alterar, () => _abstractAppService.Alterar(objeto));
        }

        [HttpPost]
        [Route("Salvar")]
        public HttpResponseMessage Salvar(TObject objeto)
        {
            return Response(TipoPermissao.Salvar, () => _abstractAppService.Salvar(objeto));
        }

        [HttpPost]
        [Route("Excluir")]
        public HttpResponseMessage Excluir(TObject objeto)
        {
            return Response(TipoPermissao.Excluir, () => _abstractAppService.Excluir(objeto));
        }

        [HttpPost]
        [Route("Sequencia")]
        public HttpResponseMessage Sequencia(TObject filtro)
        {
            return Response(TipoPermissao.Sequencia, () => _abstractAppService.Sequencia(filtro));
        }
        #endregion
    }
}