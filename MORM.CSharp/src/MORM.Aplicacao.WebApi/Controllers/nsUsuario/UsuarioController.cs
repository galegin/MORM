using System.Web.Http;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : AbstractController<Usuario>
    {
        public UsuarioController(IUsuarioAppService usuarioAppService) : base(usuarioAppService)
        {
        }
    }
}