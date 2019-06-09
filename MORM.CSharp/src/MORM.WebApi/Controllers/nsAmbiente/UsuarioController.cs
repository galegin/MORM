using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces.nsAmbiente;
using System.Web.Http;

namespace MORM.WebApi.Controllers.nsAmbiente
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : AbstractController<Usuario>
    {
        public UsuarioController(IUsuarioService usuarioService) : base(usuarioService)
        {
        }
    }
}