using System.Web.Http;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : AbstractController<Usuario>
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService) : base(null)
        {
            _usuarioAppService = usuarioAppService;
        }
    }
}