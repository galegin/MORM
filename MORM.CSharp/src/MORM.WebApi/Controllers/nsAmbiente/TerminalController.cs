using MORM.Api.Controllers;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces.nsAmbiente;
using System.Web.Http;

namespace MORM.WebApi.Controllers.nsAmbiente
{
    [RoutePrefix("api/Terminal")]
    public class TerminalController : AbstractController<Terminal>
    {
        public TerminalController(ITerminalService terminlaService) : base(terminlaService)
        {
        }
    }
}