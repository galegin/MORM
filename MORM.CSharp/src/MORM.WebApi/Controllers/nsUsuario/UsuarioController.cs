using System.Web.Http;
using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : AbstractController<Usuario>
    {
        public UsuarioController(IUsuarioApiService usuarioApiService) : base(usuarioApiService)
        {
        }
    }
}