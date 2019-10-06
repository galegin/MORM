using System.Web.Http;
using MORM.CrossCutting;
using MORM.Servico;

namespace MORM.Aplicacao.WebApi
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : AbstractController<Usuario>
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService) : base(usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }
    }
}