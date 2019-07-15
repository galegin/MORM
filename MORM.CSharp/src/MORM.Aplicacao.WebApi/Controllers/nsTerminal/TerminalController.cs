using System.Web.Http;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Aplicacao.Controllers
{
    [RoutePrefix("api/Terminal")]
    public class TerminalController : AbstractController<Terminal>
    {
        public TerminalController(ITerminalAppService terminalAppService) : base(terminalAppService)
        {
        }
    }
}