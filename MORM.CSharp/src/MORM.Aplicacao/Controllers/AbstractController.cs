using MORM.CrossCutting;
using MORM.Servico;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MORM.Aplicacao
{
    //[RoutePrefix("api/AbstractController")]
    public class AbstractController : ApiController
    {
        #region constantes
        protected const string _messageSemPermissao = "Sem permissao para acessar o servico / metodo";
        #endregion

        #region variaveis
        protected PermissaoTipo[] _listaDePermissao = {
            PermissaoTipo.Consultar,
            PermissaoTipo.Incluir,
            PermissaoTipo.Validar };
        #endregion

        #region propriedades
        public IBaseResolver Resolver { get; }
        #endregion

        #region construtores
        public AbstractController()
        {
            Resolver = new BaseResolver();
        }
        #endregion

        #region metodos
        protected virtual void VerificarPermissao(PermissaoTipo tipoPermissao)
        {
            var contemPermissao = 
                _listaDePermissao?.Contains(tipoPermissao)
                ??
                true;

            Check.That(!contemPermissao, nameof(tipoPermissao), _messageSemPermissao);
        }

        public HttpResponseMessage Response(PermissaoTipo tipo, Func<object> funcao)
        {
            try
            {
                VerificarPermissao(tipo);

                var conteudo = funcao.Invoke();

                var statusCode = conteudo is ErroOutModel ? HttpStatusCode.BadRequest 
                    : conteudo is NotFoundOutModel ? HttpStatusCode.NotFound 
                    : HttpStatusCode.OK
                    ;

                return Request.CreateResponse(statusCode, MessageHandler.CreateMessage(conteudo: conteudo));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, MessageHandler.CreateMessage(ex));
            }
        }
        #endregion
    }

    //[RoutePrefix("api/AbstractController")]
    public class AbstractController<TObject> : AbstractController, IAbstractController<TObject> 
        where TObject : class
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
                _permissaoService = Resolver.Resolve<IPermissaoAppService>();
            if (_inGravarLogAcesso)
                _logAcessoService = Resolver.Resolve<ILogAcessoAppService>();
        }

        protected void GravarLogAcesso(PermissaoTipo tipoPermissao)
        {
            var model = new GravarLogAcessoInModel
            {
                CodigoEmpresa = Ambiente.CodigoEmpresa,
                CodigoUsuario = Ambiente.CodigoUsuario,
                CodigoServico = _codigoServico,
                CodigoMetodo = tipoPermissao.ToString(),
            };

            _logAcessoService?.GravarLog(model);
        }

        protected override void VerificarPermissao(PermissaoTipo tipoPermissao)
        {
            GravarLogAcesso(tipoPermissao);

            var model = new VerificarPermissaoInModel
            {
                CodigoEmpresa = Ambiente.CodigoEmpresa,
                CodigoUsuario = Ambiente.CodigoUsuario,
                CodigoServico = _codigoServico,
                CodigoMetodo = tipoPermissao.ToString(),
            };

            var contemPermissao = _permissaoService?.VerificarPermissao(model)
                ??
                _listaDePermissao?.Contains(tipoPermissao)
                ??
                true;

            Check.That(!contemPermissao, nameof(tipoPermissao), _messageSemPermissao);
        }

        [HttpPost]
        [Route("Listar")]
        public object Listar(/*TObject*/ FilterObjeto filtro)
        {
            return Response(PermissaoTipo.Listar, () => _abstractAppService.Listar(filtro));
        }

        [HttpPost]
        [Route("Consultar")]
        public object Consultar(/*TObject*/ FilterObjeto filtro)
        {
            return Response(PermissaoTipo.Consultar, () => _abstractAppService.Consultar(filtro));
        }

        [HttpPost]
        [Route("Incluir")]
        public object Incluir(TObject objeto)
        {
            return Response(PermissaoTipo.Incluir, () => _abstractAppService.Incluir(objeto));
        }

        [HttpPost]
        [Route("Alterar")]
        public object Alterar(TObject objeto)
        {
            return Response(PermissaoTipo.Alterar, () => _abstractAppService.Alterar(objeto));
        }

        [HttpPost]
        [Route("Salvar")]
        public object Salvar(TObject objeto)
        {
            return Response(PermissaoTipo.Salvar, () => _abstractAppService.Salvar(objeto));
        }

        [HttpPost]
        [Route("Excluir")]
        public object Excluir(TObject objeto)
        {
            return Response(PermissaoTipo.Excluir, () => _abstractAppService.Excluir(objeto));
        }

        [HttpPost]
        [Route("Sequencia")]
        public object Sequencia(TObject filtro)
        {
            return Response(PermissaoTipo.Sequenciar, () => _abstractAppService.Sequenciar(filtro));
        }
        #endregion
    }
}